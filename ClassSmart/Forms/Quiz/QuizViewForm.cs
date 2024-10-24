using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Enums;
using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;
using Microsoft.IdentityModel.Tokens;
using System.Data;

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
            this.teacherDashboardForm = teacherDashboardForm;
            this.teacher = teacher;

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
                    nextQuestionBtn.Enabled = false;
                    backQuestionBtn.Enabled = false;
                    comboBox1.Enabled = false;
                    editSaveBtn.Enabled = false;
                    deleteQuizBtn.Enabled = false;
                    homeCancelBtn.Enabled = true;
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
            deleteQuizBtn.Enabled = true;

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

            if (editing)
            {
                homeCancelBtn.Text = "Cancel";
                editSaveBtn.Text = "Save";
            }
            else
            {
                homeCancelBtn.Text = "Home";
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
            Controls.Remove(mcTextBox1);
            Controls.Remove(mcTextBox2);
            Controls.Remove(mcTextBox3);
            Controls.Remove(mcTextBox4);
            Controls.Remove(questionTextBox);
            Controls.Add(questionLabel);

            if (editing)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }

            questionBackground.Size = new Size(568, 215);
            editSaveBtn.Location = new Point(11, 402);
            homeCancelBtn.Location = new Point(130, 402);
            nextQuestionBtn.Location = new Point(248, 402);
            backQuestionBtn.Location = new Point(366, 402);

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

            questionLabel.BringToFront();

            MaximumSize = new Size(608, 490);
            MinimumSize = new Size(608, 490);
            Size = new Size(608, 490);
        }

        public void showTrueFalse(Question q)
        {
            Controls.Remove(questionTextBox);
            Controls.Add(questionLabel);

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

            questionLabel.Text = q.Text;

            questionBackground.Size = new Size(568, 120);

            editSaveBtn.Location = new Point(11, 305);
            homeCancelBtn.Location = new Point(130, 305);
            nextQuestionBtn.Location = new Point(248, 305);
            backQuestionBtn.Location = new Point(366, 305);

            MaximumSize = new Size(608, 385);
            MinimumSize = new Size(608, 385);
            Size = new Size(608, 385);

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
            questionLabel.BringToFront();
        }

        private void editSaveBtn_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                var quizService = new QuizService(new ClassRepository(new ApplicationDBContext()), new QuizRepository(new ApplicationDBContext()), new UserRepository(new ApplicationDBContext()));
                var questionService = new QuestionService(new QuestionRepository(new ApplicationDBContext()));
                var answerService = new AnswerService(new AnswerRepository(new ApplicationDBContext()));

                var questions = questionService.GetQuestionsByQuizId(activeQuiz.Id);
                if (questions == null || questions.Count == 0)
                {
                    MessageBox.Show("No questions found for the selected quiz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var question = questions[questionIndex];

                if (_questions[questionIndex].Type.Equals(QuestionType.MultipleChoice))
                {
                    if (mcTextBox1.Text.IsNullOrEmpty() || mcTextBox2.Text.IsNullOrEmpty() || mcTextBox3.Text.IsNullOrEmpty() || mcTextBox4.Text.IsNullOrEmpty() || questionTextBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
                    {
                        MessageBox.Show("Please select at least one correct answer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var answers = answerService.GetAnswersByQuestionId(question.Id);
                    if (answers.Count < 4)
                    {
                        MessageBox.Show("Invalid number of answers found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    question.Text = questionTextBox.Text;
                    answers[0].Text = mcTextBox1.Text;
                    answers[1].Text = mcTextBox2.Text;
                    answers[2].Text = mcTextBox3.Text;
                    answers[3].Text = mcTextBox4.Text;
                    answers[0].IsCorrect = checkBox1.Checked;
                    answers[1].IsCorrect = checkBox2.Checked;
                    answers[2].IsCorrect = checkBox3.Checked;
                    answers[3].IsCorrect = checkBox4.Checked;

                    questionService.UpdateQuestion(question);
                    foreach (var answer in answers)
                    {
                        answerService.UpdateAnswer(answer);
                    }

                    MessageBox.Show("Question updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_questions[questionIndex].Type.Equals(QuestionType.TrueFalse))
                {
                    if (questionTextBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("Please fill out the question field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var answers = answerService.GetAnswersByQuestionId(question.Id);
                    if (answers.Count != 2)
                    {
                        MessageBox.Show("Invalid number of answers found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    question.Text = questionTextBox.Text;
                    answers[0].IsCorrect = trueRadioBtn.Checked;
                    answers[1].IsCorrect = falseRadioBtn.Checked;

                    questionService.UpdateQuestion(question);
                    foreach (var answer in answers)
                    {
                        answerService.UpdateAnswer(answer);
                    }

                    MessageBox.Show("True/False question updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                editing = false;
                editSaveBtn.Text = "Edit";
                homeCancelBtn.Text = "Home";
                clearControls();

                quizzes = _quizService.GetQuizzesByTeacher(_teacher);
                _questions = questionService.GetQuestionsByQuizId(activeQuiz.Id);

                if (_questions != null && _questions.Count > 0)
                {
                    _answers = answerService.GetAnswersByQuestionId(_questions[questionIndex].Id);
                }

                if (_questions[questionIndex].Type.Equals(QuestionType.MultipleChoice))
                {
                    showMultipleChoiceQuestion(_questions[questionIndex]);
                }
                else
                {
                    showTrueFalse(_questions[questionIndex]);
                }
            }

            else
            {
                editing = true;
                editSaveBtn.Text = "Save";
                homeCancelBtn.Text = "Cancel";
                clearControls();
                if (_questions[questionIndex].Type.Equals(QuestionType.MultipleChoice))
                {
                    showMultipleChoiceQuestionEdit(_questions[questionIndex]);
                }
                else
                {
                    showTrueFalseEdit(_questions[questionIndex]);
                }
            }
        }

        private void showMultipleChoiceQuestionEdit(Question q)
        {
            if (editing)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }

            Controls.Remove(multipleChoiceAnswer1);
            Controls.Remove(multipleChoiceAnswer2);
            Controls.Remove(multipleChoiceAnswer3);
            Controls.Remove(multipleChoiceAnswer4);
            Controls.Remove(questionLabel);

            questionTextBox = new TextBox() { Text = questionLabel.Text, Location = questionLabel.Location, Size = new Size(300, 19) };
            mcTextBox1 = new TextBox() { Text = multipleChoiceAnswer1.Text, Location = multipleChoiceAnswer1.Location, Size = new Size(300, 19) };
            mcTextBox2 = new TextBox() { Text = multipleChoiceAnswer2.Text, Location = multipleChoiceAnswer2.Location, Size = new Size(300, 19) };
            mcTextBox3 = new TextBox() { Text = multipleChoiceAnswer3.Text, Location = multipleChoiceAnswer3.Location, Size = new Size(300, 19) };
            mcTextBox4 = new TextBox() { Text = multipleChoiceAnswer4.Text, Location = multipleChoiceAnswer4.Location, Size = new Size(300, 19) };

            Controls.Add(mcTextBox1);
            Controls.Add(mcTextBox2);
            Controls.Add(mcTextBox3);
            Controls.Add(mcTextBox4);
            Controls.Add(questionTextBox);

            Controls.Add(checkBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox3);
            Controls.Add(checkBox4);

            questionTextBox.BringToFront();
            mcTextBox1.BringToFront();
            mcTextBox2.BringToFront();
            mcTextBox3.BringToFront();
            mcTextBox4.BringToFront();
            checkBox1.BringToFront();
            checkBox2.BringToFront();
            checkBox3.BringToFront();
            checkBox4.BringToFront();
        }

        private void showTrueFalseEdit(Question q)
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
            if (_answers[0].IsCorrect)
            {
                trueRadioBtn.Checked = true;
            }
            else
            {
                falseRadioBtn.Checked = true;
            }

            Controls.Remove(questionLabel);

            questionTextBox = new TextBox() { Text = questionLabel.Text, Location = questionLabel.Location, Size = new Size(300, 19) };

            Controls.Add(questionTextBox);
            Controls.Add(falseRadioBtn);
            Controls.Add(trueRadioBtn);
            Controls.Add(trueLabel);
            Controls.Add(falseLabel);

            trueRadioBtn.BringToFront();
            falseRadioBtn.BringToFront();
            questionTextBox.BringToFront();
            trueLabel.BringToFront();
            falseLabel.BringToFront();
        }

        private void nextQuestionBtn_Click(object sender, EventArgs e)
        {
            backQuestionBtn.Enabled = true;

            if (editing)
            {
                editing = false;
                editSaveBtn.Text = "Edit";
                homeCancelBtn.Text = "Home";
            }

            if (questionIndex < _questions.Count - 1)
            {
                questionIndex++;
                questionNumberLabel.Text = $"Question #{questionIndex + 1}";

                var nextQuestion = _questions[questionIndex];
                var answerService = new AnswerService(new AnswerRepository(new ApplicationDBContext()));
                _answers = answerService.GetAnswersByQuestionId(nextQuestion.Id);

                clearControls();
                LoadQuestion(nextQuestion);

                nextQuestionBtn.Enabled = questionIndex < _questions.Count - 1;
            }
            else
            {
                questionIndex++;
                questionNumberLabel.Text = $"Question #{questionIndex + 1}";
                nextQuestionBtn.Enabled = false;

                var lastQuestion = _questions[questionIndex];
                var answerService = new AnswerService(new AnswerRepository(new ApplicationDBContext()));
                _answers = answerService.GetAnswersByQuestionId(lastQuestion.Id);

                clearControls();
                LoadQuestion(lastQuestion);
            }
        }


        private void backQuestionBtn_Click(object sender, EventArgs e)
        {
            nextQuestionBtn.Enabled = true;

            if (questionIndex > 0)
            {
                questionIndex--;
                questionNumberLabel.Text = $"Question #{questionIndex + 1}";

                var previousQuestion = _questions[questionIndex];
                var answerService = new AnswerService(new AnswerRepository(new ApplicationDBContext()));
                _answers = answerService.GetAnswersByQuestionId(previousQuestion.Id);

                clearControls();
                LoadQuestion(previousQuestion);

                backQuestionBtn.Enabled = questionIndex > 0;
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearControls();
            questionIndex = 0;
            backQuestionBtn.Enabled = false;
            nextQuestionBtn.Enabled = true;

            string selectedQuizName = comboBox1.SelectedItem.ToString();

            activeQuiz = quizzes.FirstOrDefault(q => q.Name.Equals(selectedQuizName));

            if (activeQuiz != null)
            {
                questionNumberLabel.Text = "Question #1";
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

        private void LoadQuestion(Question question)
        {
            var answerService = new AnswerService(new AnswerRepository(new ApplicationDBContext()));

            _answers = new List<Answer>();

            _answers = answerService.GetAnswersByQuestionId(question.Id);

            if (question.Type == QuestionType.MultipleChoice)
            {
                if (_answers.Count == 4)
                {
                    showMultipleChoiceQuestion(question);
                }
            }
            else if (question.Type == QuestionType.TrueFalse)
            {
                if (_answers.Count == 2)
                {
                    showTrueFalse(question);
                }
            }
        }

        private void homeCancelBtn_Click(object sender, EventArgs e)
        {
            if (homeCancelBtn.Text.Equals("Cancel"))
            {
                editing = false;
                editSaveBtn.Text = "Edit";
                homeCancelBtn.Text = "Home";
                clearControls();
                if (_questions[questionIndex].Type.Equals(QuestionType.MultipleChoice))
                {
                    showMultipleChoiceQuestion(_questions[questionIndex]);
                }
                else
                {
                    showTrueFalse(_questions[questionIndex]);
                }
            }
            else
            {
                Hide();
                Dispose();
                teacherDashboardForm.Show();
            }
        }

        private void deleteQuizBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Are you sure you want to delete this quiz?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

            if (result == DialogResult.Yes)
            {
                _quizService.DeleteQuiz(activeQuiz.Id);
                MessageBox.Show("Quiz deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                quizzes = _quizService.GetQuizzesByTeacher(teacher);

                if (quizzes.IsNullOrEmpty())
                {
                    DialogResult result2 = MessageBox.Show(
                    "You currently do not have any quizzes created! Please go back and start by creating a quiz!",
                    "Back",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                    if (result2 == DialogResult.OK)
                    {
                        teacherDashboardForm.Show();
                        Hide();
                        Dispose();
                        return;
                    }
                }

                comboBox1.DataSource = quizzes.Select(q => q.Name).ToList();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
