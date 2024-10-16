using ClassSmart.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSmart.Forms
{
    public partial class TeacherDashboardForm : Form
    {
        public TeacherDashboardForm(Teacher teacher, LoginForm loginForm)
        {
            this.teacher = teacher;
            this.loginForm = loginForm;
            InitializeComponent();

            label1.Text = $"Welcome, {teacher.Name}!";
            FormClosing += new FormClosingEventHandler(TeacherDashboardForm_FormClosing);
        }

        private void TeacherDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void viewClassBtn_Click(object sender, EventArgs e)
        {

        }

        private void viewAnalyticsBtn_Click(object sender, EventArgs e)
        {

        }

        private void viewQuizzesBtn_Click(object sender, EventArgs e)
        {

        }

        private void createQuizBtn_Click(object sender, EventArgs e)
        {
            QuizCreateMainForm quizCreateMainForm = new QuizCreateMainForm(this);
            quizCreateMainForm.Show();
            Hide();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            Hide();
            Dispose();
        }
    }
}
