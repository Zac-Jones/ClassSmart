using ClassSmart.Forms.Class;
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
            List<Models.Class> classes = userService.GetClassesForStudent(student);
            int i = 50;

            foreach (Models.Class c in classes)
            {
                //Generate a new button
                Button newButton = new Button();
                newButton.Text = "Class ID: " + c.Id;
                var size = new Size(100,50);
                newButton.Size = size; // Set the size of the button
                newButton.Location = new System.Drawing.Point((Width/2) - (size.Width/2), i); // Set the location on the form
                //newButton.Click += new EventHandler(NewButton_Click);
                newButton.Click += (sender, e) => NewButton_Click(sender, e, c);
                newButton.BringToFront();
                Controls.Add(newButton);
                
                i += 50;
            }
        }

        private void NewButton_Click(object sender, EventArgs e, Models.Class c)
        {
            ClassViewQuizzesForm classViewQuizzesForm = new ClassViewQuizzesForm(c, this);
            classViewQuizzesForm.Show();
            Hide();
        }
    }
}
