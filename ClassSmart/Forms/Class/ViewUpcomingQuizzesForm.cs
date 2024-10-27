using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Model;
using ClassSmart.Services;
using ClassSmart.Models;
using ClassSmart.Utilities;

namespace ClassSmart.Forms.Class
{
    /// <summary>
    /// Form for viewing upcoming quizzes for a student.
    /// </summary>
    public partial class ViewUpcomingQuizzesForm : Form
    {
        StudentDashboardForm studentDashboardForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewUpcomingQuizzesForm"/> class.
        /// </summary>
        /// <param name="student">The student whose quizzes are to be displayed.</param>
        /// <param name="studentDashboardForm">The parent dashboard form.</param>
        public ViewUpcomingQuizzesForm(Student student, StudentDashboardForm studentDashboardForm)
        {
            this.studentDashboardForm = studentDashboardForm;
            InitializeComponent();
            DisplayQuizzes(student);
        }

        /// <summary>
        /// Displays the quizzes for the specified student.
        /// </summary>
        /// <param name="student">The student whose quizzes are to be displayed.</param>
        public void DisplayQuizzes(Student student)
        {
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());

            UserService userService = new UserService(userRepository, classRepository);
            List<Models.Class> classes = userService.GetClassesForStudent(student);

            int i = 50;
            // Displays the student's quizzes in all of the classes they are in
            foreach (Models.Class c in classes)
            {
                List<Models.Quiz> quizzes = userService.GetQuizzesForClass(c);

                // Sort quizzes by StartTime
                var sortedQuizzes = quizzes.OrderBy(q => q.StartTime).ToList();

                // Filter quizzes that are currently open
                var openQuizzes = CollectionFilterUtil.Filter(sortedQuizzes, q => q.StartTime <= DateTime.Now && q.EndTime >= DateTime.Now);
                var closedQuizzes = CollectionFilterUtil.Filter(sortedQuizzes, q => q.EndTime < DateTime.Now || q.StartTime > DateTime.Now);

                // Display open quizzes first
                DisplayQuizButtons(openQuizzes, student, ref i, true);
                // Display closed quizzes
                DisplayQuizButtons(closedQuizzes, student, ref i, false);
            }
        }

        /// <summary>
        /// Displays quiz buttons for the specified list of quizzes.
        /// </summary>
        /// <param name="quizzes">The list of quizzes to display buttons for.</param>
        /// <param name="student">The student for whom the quizzes are displayed.</param>
        /// <param name="position">The position to start displaying buttons.</param>
        /// <param name="isOpen">Indicates whether the quizzes are open or closed.</param>
        private void DisplayQuizButtons(List<Models.Quiz> quizzes, Student student, ref int position, bool isOpen)
        {
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
                if (!isOpen)
                {
                    newButton.Enabled = false; // Disable button for closed quizzes
                }
                else
                {
                    // Check if the user has already taken the quiz
                    bool hasTakenQuiz = CheckIfUserHasTakenQuiz(student.Id, q.Id);
                    if (hasTakenQuiz)
                    {
                        newButton.Enabled = false; // Disable button for taken quizzes
                    }
                }

                // Generate a new label for start and end dates
                Label dateLabel = new Label();
                dateLabel.Text = $"Start: {q.StartTime.ToShortDateString()} End: {q.EndTime.ToShortDateString()}";
                dateLabel.Location = new Point((Width / 2) - (size.Width / 2) + 120, position + 15); // Position the label beside the button
                dateLabel.AutoSize = true;
                dateLabel.BringToFront();
                Controls.Add(dateLabel);

                position += 70; // Adjust position for the next button and label
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
            AttemptRepository attemptRepository = new AttemptRepository(new ApplicationDBContext());
            AttemptService attemptService = new AttemptService(attemptRepository);
            List<QuizAttempt> quizAttempts = attemptService.GetQuizzAttemptForStudent(studentID);
            // Use generic method to check if quiz attempt exists
            var attempt = CollectionFilterUtil.FindById(quizAttempts, q => q.QuizId, quizId);
            return attempt != null; // Return true if found
        }

        /// <summary>
        /// Handles the click event for the quiz buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        /// <param name="q">The quiz associated with the button.</param>
        private void NewButton_Click(object sender, EventArgs e, Models.Quiz q)
        {
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


