using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Forms.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassSmart.Services;
using ClassSmart.Models;
using ClassSmart.Enums;

namespace ClassSmart.Forms
{
    public partial class QuizAttemptForm : Form
    {
        public QuizAttemptForm(Models.Quiz quiz, StudentDashboardForm studentDashboardForm)
        {
            InitializeComponent();

            this.studentDashboardForm = studentDashboardForm;
            this.quiz = quiz;
            QuestionRepository questionRepository = new QuestionRepository(new ApplicationDBContext());
            QuestionService questionService = new QuestionService(questionRepository);
            questions = questionService.GetQuestionsByQuizId(quiz.Id);
            currentQuestionIndex = 0;

            quizAttempt = new QuizAttempt();
            quizAttempt.QuizId = quiz.Id;
            quizAttempt.StudentId = studentDashboardForm.student.Id;

            questionAttemptList = new List<QuestionAttempt>();

            label1.Text = quiz.Name;
            DisplayQuestion();

            FormClosing += new FormClosingEventHandler(QuizAttemptForm_FormClosing);
        }

        private void QuizAttemptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void DisplayQuestion()
        {
            var percentComplete = (currentQuestionIndex + 1) * 100 / questions.Count;
            progressBar1.Value = percentComplete;

            clearControls();

            if (currentQuestionIndex == 0)
            {
                backQuestionBtn.Enabled = false;
            }
            else
            {
                backQuestionBtn.Enabled = true;
            }

            if (currentQuestionIndex == questions.Count - 1)
            {
                nextQuestionBtn.Enabled = false;
            }
            else
            {
                nextQuestionBtn.Enabled = true;
            }

            questionLabel.Text = questions[currentQuestionIndex].Text;
            questionNumberLabel.Text = $"Question {currentQuestionIndex + 1} of {questions.Count}";

            if (questions[currentQuestionIndex].Type == QuestionType.MultipleChoice)
            {
                DisplayMCQ();
            }
            else
            {
                DisplayTFQ();
            }
        }

        private void clearControls()
        {
            var controlsToRemove = new List<Control> { checkBox1, checkBox2, checkBox3, checkBox4, answerLabel1, answerLabel2, answerLabel3, answerLabel4, radioButton1, radioButton2 };
            foreach (var control in controlsToRemove)
            {
                Controls.Remove(control);
            }

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        public void DisplayMCQ()
        {
            questionBackground.Size = new Size(459, 214);
            Size = new Size(600, 413);
            MaximumSize = new Size(600, 413);
            MinimumSize = new Size(600, 413);
            homeBtn.Location = new Point(68, 331);
            nextQuestionBtn.Location = new Point(186, 331);
            backQuestionBtn.Location = new Point(304, 331);
            submitQuizBtn.Location = new Point(421, 331);

            var controlsToAdd = new List<Control> { checkBox1, checkBox2, checkBox3, checkBox4, answerLabel1, answerLabel2, answerLabel3, answerLabel4 };
            foreach (var control in controlsToAdd)
            {
                Controls.Add(control);
                control.BringToFront();
            }

            AnswerRepository answerRepository = new AnswerRepository(new ApplicationDBContext());
            AnswerService answerService = new AnswerService(answerRepository);
            List<Answer> answers = answerService.GetAnswersByQuestionId(questions[currentQuestionIndex].Id);

            answerLabel1.Text = answers[0].Text;
            answerLabel2.Text = answers[1].Text;
            answerLabel3.Text = answers[2].Text;
            answerLabel4.Text = answers[3].Text;

            foreach (var attempt in questionAttemptList)
            {
                if (attempt.QuestionId == questions[currentQuestionIndex].Id)
                {
                    attempt.AnswerIndexes.ForEach(index =>
                    {
                        switch (index)
                        {
                            case 0:
                                checkBox1.Checked = true;
                                break;
                            case 1:
                                checkBox2.Checked = true;
                                break;
                            case 2:
                                checkBox3.Checked = true;
                                break;
                            case 3:
                                checkBox4.Checked = true;
                                break;
                        }
                    });
                }
            }
        }

        public void DisplayTFQ()
        {
            questionBackground.Size = new Size(459, 130);
            Size = new Size(600, 329);
            MaximumSize = new Size(600, 329);
            MinimumSize = new Size(600, 329);

            homeBtn.Location = new Point(68, 248);
            nextQuestionBtn.Location = new Point(186, 248);
            backQuestionBtn.Location = new Point(304, 248);
            submitQuizBtn.Location = new Point(421, 248);

            var controlsToAdd = new List<Control> { answerLabel1, answerLabel2, radioButton1, radioButton2 };
            foreach (var control in controlsToAdd)
            {
                Controls.Add(control);
                control.BringToFront();
            }

            AnswerRepository answerRepository = new AnswerRepository(new ApplicationDBContext());
            AnswerService answerService = new AnswerService(answerRepository);
            List<Answer> answers = answerService.GetAnswersByQuestionId(questions[currentQuestionIndex].Id);

            answerLabel1.Text = answers[0].Text;
            answerLabel2.Text = answers[1].Text;

            foreach (var attempt in questionAttemptList)
            {
                if (attempt.QuestionId == questions[currentQuestionIndex].Id)
                {
                    attempt.AnswerIndexes.ForEach(index =>
                    {
                        switch (index)
                        {
                            case 0:
                                radioButton1.Checked = true;
                                break;
                            case 1:
                                radioButton2.Checked = true;
                                break;
                        }
                    });
                }
            }
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit? Your current answers will be submitted and the quiz will be locked.", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                CheckAndStoreAnswers();
                SubmitAnswers();
            }
        }

        private void submitQuizBtn_Click(object sender, EventArgs e)
        {
            CheckAndStoreAnswers();
            SubmitAnswers();
        }

        private void nextQuestionBtn_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < questions.Count - 1)
            {
                CheckAndStoreAnswers();
                currentQuestionIndex++;
                DisplayQuestion();
            }
        }

        private void backQuestionBtn_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                CheckAndStoreAnswers();
                currentQuestionIndex--;
                DisplayQuestion();
            }
        }

        private void CheckAndStoreAnswers()
        {
            QuestionType type = questions[currentQuestionIndex].Type;

            QuestionAttempt questionAttempt = new QuestionAttempt();
            questionAttempt.QuestionId = questions[currentQuestionIndex].Id;
            questionAttempt.QuizAttemptId = quizAttempt.Id;
            questionAttempt.AnswerIndexes = new List<int>();
            
            AnswerRepository answerRepository = new AnswerRepository(new ApplicationDBContext());
            AnswerService answerService = new AnswerService(answerRepository);

            List<int> correctAnswerIndexes = answerService.GetAnswersByQuestionId(questions[currentQuestionIndex].Id)
                .Select((answer, index) => new { answer, index })
                .Where(x => x.answer.IsCorrect)
                .Select(x => x.index)
                .ToList();

            double questionValue = questions[currentQuestionIndex].Points;
            double correctAnswerValue = questionValue / correctAnswerIndexes.Count;
            double score = 0;

            if (type == QuestionType.MultipleChoice)
            {
                if (checkBox1.Checked)
                {
                    questionAttempt.AnswerIndexes.Add(0);
                    score += correctAnswerIndexes.Contains(0) ? correctAnswerValue : -correctAnswerValue;
                }

                if (checkBox2.Checked)
                {
                    questionAttempt.AnswerIndexes.Add(1);
                    score += correctAnswerIndexes.Contains(1) ? correctAnswerValue : -correctAnswerValue;
                }

                if (checkBox3.Checked)
                {
                    questionAttempt.AnswerIndexes.Add(2);
                    score += correctAnswerIndexes.Contains(2) ? correctAnswerValue : -correctAnswerValue;
                }

                if (checkBox4.Checked)
                {
                    questionAttempt.AnswerIndexes.Add(3);
                    score += correctAnswerIndexes.Contains(3) ? correctAnswerValue : -correctAnswerValue;
                }

                if (score < 0)
                {
                    score = 0;
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    questionAttempt.AnswerIndexes.Add(0);
                    score += correctAnswerIndexes.Contains(0) ? correctAnswerValue : 0;
                }
                else if (radioButton2.Checked)
                {
                    questionAttempt.AnswerIndexes.Add(1);
                    score += correctAnswerIndexes.Contains(1) ? correctAnswerValue : 0;
                }
            }

            questionAttempt.Score = score;

            foreach (var attempt in questionAttemptList)
            {
                if (attempt.QuestionId == questionAttempt.QuestionId)
                {
                    questionAttemptList.Remove(attempt);
                    break;
                }
            }

            questionAttemptList.Add(questionAttempt);
        }

        private void SubmitAnswers()
        {
            if (questionAttemptList.Count == questions.Count)
            {
                SaveAnswers();
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to submit your quiz attempt? You have not answered all of the questions!", "Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveAnswers();
                }
            }
        }

        private void SaveAnswers()
        {
            AttemptRepository attemptRepository = new AttemptRepository(new ApplicationDBContext());
            AttemptService attemptService = new AttemptService(attemptRepository);

            quizAttempt.Score = questionAttemptList.Sum(attempt => attempt.Score);
            quizAttempt.QuestionAttempts = questionAttemptList;

            attemptService.AddQuizAttempt(quizAttempt);

            Hide();
            Dispose();
            studentDashboardForm.Show();
        }
    }
}
