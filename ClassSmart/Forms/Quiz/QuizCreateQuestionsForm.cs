using ClassSmart.Enums;
using ClassSmart.Models;
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
        public QuizCreateQuestionsForm(TeacherDashboardForm teacherDashboardForm, QuizCreateMainForm quizCreateMainForm, Models.Quiz quiz, int numOfQuestions)
        {
            this.teacherDashboardForm = teacherDashboardForm;
            this.quizCreateMainForm = quizCreateMainForm;
            this.quiz = quiz;

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
            
        }

        private void displayLongAnswer()
        {
            
        }

        private void displayShortAnswer()
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearControls();
            if (comboBox1.SelectedItem != null)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "MultipleChoice":
                        displayMultipleChoice();
                        break;

                    case "TrueFalse":
                        displayTrueFalse();
                        break;

                    case "LongAnswer":
                        displayLongAnswer();
                        break;

                    case "ShortAnswer":
                        displayShortAnswer();
                        break;
                }

                Controls.Add(label5);
                Controls.Add(textBox5);
            }
        }

        private void clearControls()
        {
            var controlsToRemove = new List<Control> { checkBox1, checkBox2, checkBox3, checkBox4, label3, label4, textBox1, textBox2,
                textBox3, textBox4, label5, textBox5 };

            foreach (var control in controlsToRemove)
            {
                Controls.Remove(control);
            }
        }
    }
}
