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
using ClassSmart.Services;

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
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());

            UserService userService = new UserService(userRepository, classRepository);
            List<Class> classes = userService.GetClassesForStudent(student);


            foreach (Class c in classes)
            {
                MessageBox.Show($"Class ID: {c.Id}");
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
