using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Forms.Main;
using ClassSmart.Model;
using ClassSmart.Services;
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

namespace ClassSmart.Forms.Class
{
    public partial class ClassViewQuizzesForm : Form
    {
        public ClassViewQuizzesForm(Models.Class c, StudentClassDetailsForm studentClassDetailForm)
        {
            InitializeComponent();
            DisplayQuizzes(c);
        }

        private void DisplayQuizzes(Models.Class c)
        {
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());

            UserService userService = new UserService(userRepository, classRepository);
            List<Models.Quiz> quizzes = userService.GetQuizzesForClass(c);

            int i = 50;
            foreach (Models.Quiz q in quizzes)
            {
                //Generate a new button
                Button newButton = new Button();
                newButton.Text = "Quiz Name: " + Environment.NewLine + q.Name + " (ID:" + q.Id + ")";
                var size = new Size(100, 50);
                newButton.Size = size; // Set the size of the button
                newButton.Location = new System.Drawing.Point((Width / 2) - (size.Width / 2), i); // Set the location on the form
                //newButton.Click += new EventHandler(NewButton_Click);
                newButton.Click += (sender, e) => NewButton_Click(sender, e, q);
                newButton.BringToFront();
                Controls.Add(newButton);

                i += 50;
            }
        }
        private void NewButton_Click(object sender, EventArgs e, Models.Quiz q)
        {
            QuizAttemptForm quizAttemptForm = new QuizAttemptForm(q, this);
            quizAttemptForm.Show();
            Hide();
        }
    }
}
