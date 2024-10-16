using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassSmart.Models;
using ClassSmart.Model;
using ClassSmart.Forms.Main;

namespace ClassSmart.Forms
{
    public partial class TeacherDashboardForm : Form
    {
        //private Teacher teacher;
        //private LoginForm loginForm;

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

            Class teacherClass = teacher.Class;
            ClassDetailsForm classDetailsForm = new ClassDetailsForm(teacherClass, this);
            classDetailsForm.Show();
            Hide();
        }

        private void viewAnalyticsBtn_Click(object sender, EventArgs e)
        {
            AnalyticsForm analyticsForm = new AnalyticsForm();
            analyticsForm.Show();
            Hide();
        }

        private void viewQuizzesBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void createQuizBtn_Click(object sender, EventArgs e)
        {
            QuizCreateMainForm quizCreateMainForm = new QuizCreateMainForm(teacher, this);
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
