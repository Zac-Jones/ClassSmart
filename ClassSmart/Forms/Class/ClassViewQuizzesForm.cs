using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Forms.Main;
using ClassSmart.Services;
using ClassSmart.Models;
using ClassSmart.Utilities;

namespace ClassSmart.Forms.Class
{
    /// <summary>
    /// Form for viewing quizzes in a class.
    /// </summary>
    public partial class ClassViewQuizzesForm : Form
    {
        StudentClassDetailsForm studentClassDetailsForm;
        StudentDashboardForm studentDashboardForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassViewQuizzesForm"/> class.
        /// </summary>
        /// <param name="c">The class whose quizzes are to be displayed.</param>
        /// <param name="studentClassDetailsForm">The parent class details form.</param>
        /// <param name="studentDashboardForm">The parent dashboard form.</param>
        public ClassViewQuizzesForm(Models.Class c, StudentClassDetailsForm studentClassDetailsForm, StudentDashboardForm studentDashboardForm)
        {
            this.studentClassDetailsForm = studentClassDetailsForm;
            this.studentDashboardForm = studentDashboardForm;
            InitializeComponent();
            DisplayQuizzes(c);
        }

        /// <summary>
        /// Displays the quizzes for the specified class.
        /// </summary>
        /// <param name="c">The class whose quizzes are to be displayed.</param>
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

        /// <summary>
        /// Displays quiz buttons for the specified list of quizzes.
        /// </summary>
        /// <param name="quizzes">The list of quizzes to display buttons for.</param>
        /// <param name="position">The position to start displaying buttons.</param>
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

        /// <summary>
        /// Checks if the user has taken the specified quiz.
        /// </summary>
        /// <param name="studentID">The ID of the student.</param>
        /// <param name="quizId">The ID of the quiz.</param>
        /// <returns>True if the user has taken the quiz, otherwise false.</returns>
        private bool CheckIfUserHasTakenQuiz(long studentID, long quizId)
        {
            // Initialize repositories and services
            AttemptRepository attemptRepository = new AttemptRepository(new ApplicationDBContext());
            AttemptService attemptService = new AttemptService(attemptRepository);

            // Get quiz attempts for the student
            List<QuizAttempt> quizAttempts = attemptService.GetQuizzAttemptForStudent(studentID);
            return quizAttempts.Any(q => q.QuizId == quizId); // Simplified check
        }

        /// <summary>
        /// Handles the click event for the quiz buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        /// <param name="q">The quiz associated with the button.</param>
        private void NewButton_Click(object sender, EventArgs e, Models.Quiz q)
        {
            // Open the quiz attempt form
            QuizAttemptForm quizAttemptForm = new QuizAttemptForm(q, studentDashboardForm);
            quizAttemptForm.Show();
            Hide();
        }

        /// <summary>
        /// Handles the Cancel button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            studentDashboardForm.Show();
            Hide();
            Dispose();
        }
    }
}

