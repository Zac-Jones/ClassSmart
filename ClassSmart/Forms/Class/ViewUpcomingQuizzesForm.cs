using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Model;
using ClassSmart.Services;
using ClassSmart.Models;
using Microsoft.Identity.Client;

namespace ClassSmart.Forms.Class
{
    public partial class ViewUpcomingQuizzesForm : Form
    {
        StudentDashboardForm studentDashboardForm;
        public ViewUpcomingQuizzesForm(Student student, StudentDashboardForm studentDashboardForm)
        {
            this.studentDashboardForm = studentDashboardForm;
            InitializeComponent();
            DisplayQuizzes(student);
        }

        public void DisplayQuizzes(Student student)
        {
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());

            UserService userService = new UserService(userRepository, classRepository);
            List<Models.Class> classes = userService.GetClassesForStudent(student);

            int i = 50;
            //Displays the student's quizzes in all of the classes they are in
            foreach (Models.Class c in classes)
            {
                List<Models.Quiz> quizzes = userService.GetQuizzesForClass(c);

                // Sort quizzes by StartTime
                var sortedQuizzes = quizzes.OrderBy(q => q.StartTime).ToList();

                foreach (Models.Quiz q in sortedQuizzes)
                {
                    //Generate a new button
                    Button newButton = new Button();
                    newButton.Text = "Quiz Name: " + Environment.NewLine + q.Name + " (ID:" + q.Id + ")";
                    var size = new Size(100, 50);
                    newButton.Size = size; // Set the size of the button
                    newButton.Location = new System.Drawing.Point((Width / 2) - (size.Width / 2), i); // Set the location on the form
                    newButton.Click += (sender, e) => NewButton_Click(sender, e, q);
                    newButton.BringToFront();
                    Controls.Add(newButton);

                    // Check if quiz start date hasn't happened yet
                    if (DateTime.Now < q.StartTime)
                    {
                        newButton.Enabled = false; // Disable button for future quizzes
                    }
                    else
                    {
                        // Check if user has already taken the quiz (implementation depends on your logic)
                        bool hasTakenQuiz = CheckIfUserHasTakenQuiz(student.Id, q.Id);
                        if (hasTakenQuiz)
                        {
                            newButton.Enabled = false; // Disable button for taken quizzes
                        }
                    }

                    // Generate a new label for start and end dates
                    Label dateLabel = new Label();
                    dateLabel.Text = $"Start: {q.StartTime.ToShortDateString()} End: {q.EndTime.ToShortDateString()}";
                    dateLabel.Location = new System.Drawing.Point((Width / 2) - (size.Width / 2) + 120, i + 15); // Position the label beside the button
                    dateLabel.AutoSize = true;
                    dateLabel.BringToFront();
                    Controls.Add(dateLabel);

                    i += 70; // Adjust position for the next button and label
                }
            }

            
        }

        private bool CheckIfUserHasTakenQuiz(long studentID, long quizId)
        {
            AttemptRepository attemptRepository = new AttemptRepository(new ApplicationDBContext());
            AttemptService attemptService = new AttemptService(attemptRepository);
            List<QuizAttempt> quizAttempts = attemptService.GetQuizzAttemptForStudent(studentID);
            foreach(Models.QuizAttempt q in quizAttempts)
            {
                if(q.QuizId == quizId)
                {
                    return true;
                }
            }
            return false;
        }

        private void NewButton_Click(object sender, EventArgs e, Models.Quiz q)
        {
            QuizAttemptForm quizAttemptForm = new QuizAttemptForm(q, studentDashboardForm);
            quizAttemptForm.Show();
            Hide();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are You Sure You Want To Cancel?",
            "Confirm Cancel",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                studentDashboardForm.Show();
                Hide();
                Dispose();
            }
        }
    }
}
