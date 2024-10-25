using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Forms.Main;
using ClassSmart.Model;
using ClassSmart.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClassSmart.Models;
using ClassSmart.Utilities;

namespace ClassSmart.Forms.Class
{
    public partial class ClassViewQuizzesForm : Form
    {
        StudentClassDetailsForm studentClassDetailsForm;
        StudentDashboardForm studentDashboardForm;

        public ClassViewQuizzesForm(Models.Class c, StudentClassDetailsForm studentClassDetailsForm, StudentDashboardForm studentDashboardForm)
        {
            this.studentClassDetailsForm = studentClassDetailsForm;
            this.studentDashboardForm = studentDashboardForm;
            InitializeComponent();
            DisplayQuizzes(c);
        }

        private void DisplayQuizzes(Models.Class c)
        {
            // Initialize repositories and services
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());
            UserService userService = new UserService(userRepository, classRepository);

            // Get quizzes for the class
            List<Models.Quiz> quizzes = userService.GetQuizzesForClass(c);

            // Sort quizzes by StartTime
            var sortedQuizzes = quizzes.OrderBy(q => q.StartTime).ToList();

            // Filter quizzes that are currently open
            var openQuizzes = CollectionFilterUtil.Filter(sortedQuizzes, q => q.StartTime <= DateTime.Now && q.EndTime >= DateTime.Now);
            var closedQuizzes = CollectionFilterUtil.Filter(sortedQuizzes, q => q.EndTime < DateTime.Now || q.StartTime > DateTime.Now);

            int i = 50;

            // Display open quizzes first
            DisplayQuizButtons(openQuizzes, ref i);
            // Display closed quizzes
            DisplayQuizButtons(closedQuizzes, ref i);
        }

        private void DisplayQuizButtons(List<Models.Quiz> quizzes, ref int position)
        {
            // Get the student's ID from the dashboard form (assumed to be available)
            long studentId = studentDashboardForm.student.Id; // Assuming a method exists to get the student's ID

            foreach (Models.Quiz q in quizzes)
            {
                // Generate a new button
                Button newButton = new Button();
                newButton.Text = "Quiz Name: " + Environment.NewLine + q.Name + " (ID:" + q.Id + ")";
                var size = new Size(100, 50);
                newButton.Size = size; // Set the size of the button
                newButton.Location = new Point((Width / 2) - (size.Width / 2), position); // Set the location on the form
                newButton.Click += (sender, e) => NewButton_Click(sender, e, q);
                newButton.BringToFront();
                Controls.Add(newButton);

                // Disable the button for closed quizzes
                if (q.EndTime < DateTime.Now || q.StartTime > DateTime.Now)
                {
                    newButton.Enabled = false; // Disable button for closed quizzes
                }
                else
                {
                    // Check if the quiz has already been taken
                    bool hasTakenQuiz = CheckIfUserHasTakenQuiz(studentId, q.Id);
                    if (hasTakenQuiz)
                    {
                        newButton.Enabled = false; // Disable button for taken quizzes
                    }
                }

                position += 70; // Adjust position for the next button
            }
        }

        private bool CheckIfUserHasTakenQuiz(long studentID, long quizId)
        {
            // Initialize repositories and services
            AttemptRepository attemptRepository = new AttemptRepository(new ApplicationDBContext());
            AttemptService attemptService = new AttemptService(attemptRepository);

            // Get quiz attempts for the student
            List<QuizAttempt> quizAttempts = attemptService.GetQuizzAttemptForStudent(studentID);
            return quizAttempts.Any(q => q.QuizId == quizId); // Simplified check
        }

        private void NewButton_Click(object sender, EventArgs e, Models.Quiz q)
        {
            // Open the quiz attempt form
            QuizAttemptForm quizAttemptForm = new QuizAttemptForm(q, studentDashboardForm);
            quizAttemptForm.Show();
            Hide();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
            "Are You Sure You Want To Cancel?",
            "Confirm Cancel",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                // Show the student class details form and hide the current form
                studentClassDetailsForm.Show();
                Hide();
                Dispose();
            }
        }
    }
}
