using ClassSmart.Forms.Main;
using ClassSmart.Forms.Class;
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
    public partial class StudentDashboardForm : Form
    {
        public StudentDashboardForm(Student student, LoginForm loginForm)
        {
            this.student = student;
            this.loginForm = loginForm;
            InitializeComponent();

            label1.Text = $"Welcome, {student.Name}!";
            FormClosing += new FormClosingEventHandler(StudentDashboardForm_FormClosing);
        }

        private void StudentDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void viewClassesBtn_Click(object sender, EventArgs e)
        {
            StudentClassDetailsForm studentClassDetailsForm = new StudentClassDetailsForm(student, this);
            studentClassDetailsForm.Show();
            Hide();
        }

        private void viewUpcomingQuizzesBtn_Click(object sender, EventArgs e)
        {
            ViewUpcomingQuizzesForm viewUpcomingQuizzesForm = new ViewUpcomingQuizzesForm(student, this);
            viewUpcomingQuizzesForm.Show();
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
