using ClassSmart.Forms.Quiz;
using ClassSmart.Model;
using ClassSmart.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClassSmart.Forms
{
    public partial class QuizCreateMainForm : Form
    {
        public QuizCreateMainForm(Teacher teacher, TeacherDashboardForm teacherDashboardForm)
        {
            this.teacherDashboardForm = teacherDashboardForm;
            this.teacher = teacher;
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(QuizCreateForm_FormClosing);
        }

        private void QuizCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addQuestionsBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IsNullOrEmpty())
            {
                errorLabel.Text = "Please fill in all fields";
                return;
            }

            if (dateTimePicker1.Value < DateTime.Now)
            {
                errorLabel.Text = "Please select a valid start date";
                return;
            }

            if (dateTimePicker2.Value < DateTime.Now)
            {
                errorLabel.Text = "Please select a valid end date";
                return;
            }

            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                errorLabel.Text = "End date must be after start date";
                return;
            }

            if (numericUpDown2.Value == 0)
            {
                errorLabel.Text = "Please select a valid amount of questions";
                return;
            }

            if (numericUpDown3.Value == 0)
            {
                errorLabel.Text = "Please select a valid test weight";
                return;
            }

            errorLabel.Text = "";

            Models.Quiz quiz = new Models.Quiz();
            quiz.Name = textBox1.Text;
            quiz.StartTime = dateTimePicker1.Value;
            quiz.EndTime = dateTimePicker2.Value;
            quiz.TotalPoints = (double)numericUpDown3.Value;

            QuizCreateQuestionsForm quizCreateQuestionsForm = new QuizCreateQuestionsForm(teacher, teacherDashboardForm, this, quiz, (int)numericUpDown2.Value);
            quizCreateQuestionsForm.Show();
            Hide();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            teacherDashboardForm.Show();
            Hide();
            Dispose();
        }
    }
}
