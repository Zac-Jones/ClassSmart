using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Enums;
using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;
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

namespace ClassSmart.Forms.Quiz
{
    public partial class QuizCreateQuestionsForm : Form
    {
        public QuizCreateQuestionsForm(Teacher teacher, TeacherDashboardForm teacherDashboardForm, QuizCreateMainForm quizCreateMainForm, Models.Quiz quiz, int numOfQuestions)
        {
            this.teacherDashboardForm = teacherDashboardForm;
            this.quizCreateMainForm = quizCreateMainForm;
            this.quiz = quiz;
            this.numOfQuestions = numOfQuestions;
            this.teacher = teacher;

            var dbContext = new ApplicationDBContext();
            var classRepository = new ClassRepository(dbContext);
            var quizRepository = new QuizRepository(dbContext);
            var userRepository = new UserRepository(dbContext);

            _quizService = new QuizService(classRepository, quizRepository, userRepository);


            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(QuestionType));
            FormClosing += new FormClosingEventHandler(QuizCreaeQuestionsForm_FormClosing);
            label1.Text = $"Quiz: {quiz.Name} - Question #{questionNumber}";
        }

        private void QuizCreaeQuestionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void displayMultipleChoice()
        {
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
        }

        private void displayTrueFalse()
        {
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(label7);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearControls();
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == QuestionType.MultipleChoice.ToString())
                {
                    displayMultipleChoice();
                }
                else
                {
                    displayTrueFalse();
                }

                Controls.Add(label5);
                Controls.Add(textBox5);
            }
        }

        private void clearControls()
        {
            var controlsToRemove = new List<Control> { checkBox1, checkBox2, checkBox3, checkBox4, label3, label4, textBox1, textBox2,
                textBox3, textBox4, label5, textBox5, radioButton1, radioButton2, textBox7, textBox6, label7, label6 };

            foreach (var control in controlsToRemove)
            {
                Controls.Remove(control);
            }
        }

        private void nextQuestionBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == QuestionType.MultipleChoice.ToString())
                {
                    if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty() ||
                        textBox3.Text.IsNullOrEmpty() || textBox4.Text.IsNullOrEmpty() ||
                        textBox5.Text.IsNullOrEmpty())
                    {
                        errorLabel.Text = "Please fill in all fields";
                        return;
                    }
                    else if (!checkBox1.Checked && !checkBox2.Checked &&
                             !checkBox3.Checked && !checkBox4.Checked)
                    {
                        errorLabel.Text = "Please select at least one correct answer";
                        return;
                    }

                    Question question = new Question
                    {
                        Type = QuestionType.MultipleChoice,
                        Text = textBox5.Text,
                        Answers = new List<Answer>
                        {
                            new Answer { Text = textBox1.Text, IsCorrect = checkBox1.Checked },
                            new Answer { Text = textBox2.Text, IsCorrect = checkBox2.Checked },
                            new Answer { Text = textBox3.Text, IsCorrect = checkBox3.Checked },
                            new Answer { Text = textBox4.Text, IsCorrect = checkBox4.Checked }
                        },
                        Points = quiz.TotalPoints / numOfQuestions
                    };

                    quiz.Questions.Add(question);

                    incrementQuestion();
                }
                else
                {
                    if (textBox6.Text.IsNullOrEmpty() || textBox7.Text.IsNullOrEmpty() ||
                        textBox5.Text.IsNullOrEmpty())
                    {
                        errorLabel.Text = "Please fill in all fields";
                        return;
                    }
                    else if (!radioButton1.Checked && !radioButton2.Checked)
                    {
                        errorLabel.Text = "Please select the correct answer";
                        return;
                    }

                    Question question = new Question
                    {
                        Type = QuestionType.TrueFalse,
                        Text = textBox5.Text,
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "True", IsCorrect = radioButton1.Checked },
                            new Answer { Text = "False", IsCorrect = radioButton2.Checked }
                        },
                        Points = quiz.TotalPoints / numOfQuestions
                    };

                    quiz.Questions.Add(question);

                    incrementQuestion();
                }
            }
        }

        private void incrementQuestion()
        {
            questionNumber++;

            if (questionNumber == numOfQuestions)
            {
                nextQuestionBtn.Text = "Submit Quiz";
            }

            if (questionNumber > numOfQuestions)
            {
                _quizService.CreateQuizForTeacher(teacher, quiz);

                MessageBox.Show("Quiz created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                teacherDashboardForm.Show();
                Hide();
                Dispose();
            }
            else
            {
                label1.Text = $"Quiz: {quiz.Name} - Question #{questionNumber}";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                comboBox1.SelectedIndex = 0;

                errorLabel.Text = string.Empty;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "This will delete any and all progress on the current quiz and return to the main menu. Do you want to continue?",
                "Confirm Cancel",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                teacherDashboardForm.Show();
                Hide();
                Dispose();
                quizCreateMainForm.Dispose();
            }
        }
    }
}
