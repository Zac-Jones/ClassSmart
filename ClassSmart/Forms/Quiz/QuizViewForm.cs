using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Enums;
using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClassSmart.Forms.TeacherSpecific
{
    public partial class QuizViewForm : Form
    {
        public QuizViewForm(Teacher teacher, TeacherDashboardForm teacherDashboardForm)
        {
            InitializeComponent();
            var dbContext = new ApplicationDBContext();
            var classRepository = new ClassRepository(dbContext);
            var quizRepository = new QuizRepository(dbContext);
            var userRepository = new UserRepository(dbContext);

            _quizService = new QuizService(classRepository, quizRepository, userRepository);

            FormClosing += new FormClosingEventHandler(QuizViewForm_FormClosing);
            _teacher = teacher;
            quizzes = _quizService.GetQuizzesByTeacher(teacher);

            if (quizzes.IsNullOrEmpty())
            {
                DialogResult result = MessageBox.Show(
                "You currently do not have any quizzes created! Please go back and start by creating a quiz!",
                "Back",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

                if (result == DialogResult.OK)
                {
                    teacherDashboardForm.Show();
                    Hide();
                    Dispose();
                    return;
                }
            }

            comboBox1.DataSource = quizzes.Select(q => q.Name).ToList();

            foreach (var quiz in quizzes)
            {
                if (comboBox1.SelectedItem.ToString().Equals(quiz.Name))
                {
                    activeQuiz = quiz;
                }
            }

            var questionService = new QuestionService(new QuestionRepository(new ApplicationDBContext()));
            _questions = questionService.GetQuestionsByQuizId(activeQuiz.Id);

            if (_questions != null && _questions.Count > 0)
            {
                var answerService = new AnswerService(new AnswerRepository(new ApplicationDBContext()));
                _answers = answerService.GetAnswersByQuestionId(_questions.First().Id);
                // Now you can check the type of the first question
                if (_questions.First().Type.Equals(QuestionType.MultipleChoice))
                {
                    showMultipleChoiceQuestion(_questions.First());
                }
                else
                {
                    showTrueFalse(_questions.First());
                }
            }

            if (editing)
            {
                deleteCancelBtn.Text = "Cancel";
                editSaveBtn.Text = "Save";
            }
            else
            {
                deleteCancelBtn.Text = "Delete";
                editSaveBtn.Text = "Edit";
            }
        }

        private void QuizViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void clearControls()
        {
            var controlsToRemove = new List<Control> { checkBox1, checkBox2, checkBox3, checkBox4, multipleChoiceAnswer1, multipleChoiceAnswer2, multipleChoiceAnswer3, multipleChoiceAnswer4, trueLabel, falseLabel, falseRadioBtn, trueRadioBtn };
            foreach (var control in controlsToRemove)
            {
                Controls.Remove(control);
            }
        }
        public void showMultipleChoiceQuestion(Question q)
        {
            if (editing)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            } else
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }

            questionBackground.Size = new Size(568, 215);
            editSaveBtn.Location = new Point(11, 402);
            deleteCancelBtn.Location = new Point(130, 402);
            nextQuestionBtn.Location = new Point(248, 402);
            backQuestionBtn.Location = new Point(366, 402);
            homeBtn.Location = new Point(485, 402);

            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);

            Controls.Add(multipleChoiceAnswer4);
            Controls.Add(multipleChoiceAnswer3);
            Controls.Add(multipleChoiceAnswer2);
            Controls.Add(multipleChoiceAnswer1);

            questionLabel.Text = q.Text;
            multipleChoiceAnswer1.Text = _answers[0].Text;
            multipleChoiceAnswer2.Text = _answers[1].Text;
            multipleChoiceAnswer3.Text = _answers[2].Text;
            multipleChoiceAnswer4.Text = _answers[3].Text;

            checkBox1.Checked = _answers[0].IsCorrect;
            checkBox2.Checked = _answers[1].IsCorrect;
            checkBox3.Checked = _answers[2].IsCorrect;
            checkBox4.Checked = _answers[3].IsCorrect;

            checkBox1.BringToFront();
            checkBox2.BringToFront();
            checkBox3.BringToFront();
            checkBox4.BringToFront();

            multipleChoiceAnswer1.BringToFront();
            multipleChoiceAnswer2.BringToFront();
            multipleChoiceAnswer3.BringToFront();
            multipleChoiceAnswer4.BringToFront();


        }

        public void showTrueFalse(Question q)
        {
            if (editing)
            {
                trueRadioBtn.Enabled = true;
                falseRadioBtn.Enabled = true;
            }
            else
            {
                trueRadioBtn.Enabled = false;
                falseRadioBtn.Enabled = false;
            }

            questionBackground.Size = new Size(568, 120);

            editSaveBtn.Location = new Point(11, 311);
            deleteCancelBtn.Location = new Point(130, 311);
            nextQuestionBtn.Location = new Point(248, 311);
            backQuestionBtn.Location = new Point(366, 311);
            homeBtn.Location = new Point(485, 311);


            Controls.Add(falseRadioBtn);
            Controls.Add(trueRadioBtn);

            Controls.Add(falseLabel);
            Controls.Add(trueLabel);

            if (_answers[0].IsCorrect)
            {
                trueRadioBtn.Checked = true;
            }
            else
            {
                falseRadioBtn.Checked = true;
            }

            falseLabel.BringToFront();
            trueLabel.BringToFront();
            trueRadioBtn.BringToFront();
            falseRadioBtn.BringToFront();

        }

        private void editSaveBtn_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                // do save here
                editing = false;
                editSaveBtn.Text = "Edit";
                Refresh();
            }
            else
            {
                // enable editing here
                editing = true;
                editSaveBtn.Text = "Save";
                Refresh();
            }
        }

        private void nextQuestionBtn_Click(object sender, EventArgs e)
        {
            // display next question
            backQuestionBtn.Enabled = true;
            // once at last question disable next button
        }

        private void backQuestionBtn_Click(object sender, EventArgs e)
        {
            // display previous question
            // once at first question disable back button
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearControls();

            string selectedQuizName = comboBox1.SelectedItem.ToString();

            activeQuiz = quizzes.FirstOrDefault(q => q.Name.Equals(selectedQuizName));

            if (activeQuiz != null)
            {
                var questionService = new QuestionService(new QuestionRepository(new ApplicationDBContext()));
                _questions = questionService.GetQuestionsByQuizId(activeQuiz.Id);


                if (_questions != null && _questions.Count > 0)
                {
                    var answerService = new AnswerService(new AnswerRepository(new ApplicationDBContext()));
                    _answers = answerService.GetAnswersByQuestionId(_questions.First().Id);

                    if (_questions.First().Type.Equals(QuestionType.MultipleChoice))
                    {
                        showMultipleChoiceQuestion(_questions.First());
                    }
                    else
                    {
                        showTrueFalse(_questions.First());
                    }
                }
            }
        }
    }
}
