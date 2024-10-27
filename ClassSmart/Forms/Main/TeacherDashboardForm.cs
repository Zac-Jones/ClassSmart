using ClassSmart.Model;
using ClassSmart.Forms.Main;
using ClassSmart.Forms.TeacherSpecific;

namespace ClassSmart.Forms
{
    /// <summary>
    /// Form for displaying the teacher dashboard.
    /// </summary>
    public partial class TeacherDashboardForm : Form
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherDashboardForm"/> class.
        /// </summary>
        /// <param name="teacher">The teacher associated with this dashboard.</param>
        /// <param name="loginForm">The login form to return to after logging out.</param>
        public TeacherDashboardForm(Teacher teacher, LoginForm loginForm)
        {
            this.teacher = teacher;
            this.loginForm = loginForm;
            InitializeComponent();

            label1.Text = $"Welcome, {teacher.Name}!";
            FormClosing += new FormClosingEventHandler(TeacherDashboardForm_FormClosing);
        }

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TeacherDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the view class button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void viewClassBtn_Click(object sender, EventArgs e)
        {
            TeacherClassDetailsForm classDetailsForm = new TeacherClassDetailsForm(teacher, this);
            classDetailsForm.Show();
            Hide();
        }

        /// <summary>
        /// Handles the view analytics button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void viewAnalyticsBtn_Click(object sender, EventArgs e)
        {
            Main.TeacherAnalyticsForm teacherAnalyticsForm = new Main.TeacherAnalyticsForm(teacher, this);
            teacherAnalyticsForm.Show();
            Hide();
        }

        /// <summary>
        /// Handles the view quizzes button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void viewQuizzesBtn_Click(object sender, EventArgs e)
        {
            QuizViewForm quizViewForm = new QuizViewForm(teacher, this);
            quizViewForm.Show();
            Hide();
        }

        /// <summary>
        /// Handles the create quiz button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void createQuizBtn_Click(object sender, EventArgs e)
        {
            QuizCreateMainForm quizCreateMainForm = new QuizCreateMainForm(teacher, this);
            quizCreateMainForm.Show();
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
    }
}
