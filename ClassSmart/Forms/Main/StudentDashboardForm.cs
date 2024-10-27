using ClassSmart.Forms.Main;
using ClassSmart.Forms.Class;
using ClassSmart.Model;

namespace ClassSmart.Forms
{
    /// <summary>
    /// Form for displaying the student dashboard.
    /// </summary>
    public partial class StudentDashboardForm : Form
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentDashboardForm"/> class.
        /// </summary>
        /// <param name="student">The student associated with this dashboard.</param>
        /// <param name="loginForm">The login form to return to after logging out.</param>
        public StudentDashboardForm(Student student, LoginForm loginForm)
        {
            this.student = student;
            this.loginForm = loginForm;
            InitializeComponent();

            label1.Text = $"Welcome, {student.Name}!";
            FormClosing += new FormClosingEventHandler(StudentDashboardForm_FormClosing);
        }

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void StudentDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the view classes button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void viewClassesBtn_Click(object sender, EventArgs e)
        {
            StudentClassDetailsForm studentClassDetailsForm = new StudentClassDetailsForm(student, this);
            studentClassDetailsForm.Show();
            Hide();
        }

        /// <summary>
        /// Handles the view upcoming quizzes button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void viewUpcomingQuizzesBtn_Click(object sender, EventArgs e)
        {
            ViewUpcomingQuizzesForm viewUpcomingQuizzesForm = new ViewUpcomingQuizzesForm(student, this);
            viewUpcomingQuizzesForm.Show();
            Hide();
        }

        /// <summary>
        /// Handles the logout button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            Hide();
            Dispose();
        }

        /// <summary>
        /// Handles the analytics button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void analyticsBtn_Click(object sender, EventArgs e)
        {
            StudentAnalyticsForm studentAnalyticsForm = new StudentAnalyticsForm(student, this);
            studentAnalyticsForm.Show();
            Hide();
        }
    }
}
