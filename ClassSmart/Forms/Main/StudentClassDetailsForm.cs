using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Model;
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

namespace ClassSmart.Forms.Main
{
    public partial class StudentClassDetailsForm : Form
    {
        public StudentClassDetailsForm(Student student, StudentDashboardForm studentDashboardForm)
        {
            InitializeComponent();
            button1.Text = "Quiz";
            DisplayClass(student);

            FormClosing += new FormClosingEventHandler(StudentClassDetailsForm_FormClosing);
        }

        private void StudentClassDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Method to Display Class Information
        private void DisplayClass(Student student)
        {
            ClassRepository cR = new ClassRepository(new ApplicationDBContext());
            List<Class> classes = student.Classes;


            foreach (Class c in classes)
            {
                List<Models.Quiz> quizzes = c.Quizzes;
                int i = 50;

                button1.Text = Convert.ToString(c.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($" Button Clicked!");
        }
    }
}
