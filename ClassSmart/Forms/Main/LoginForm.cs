using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Services;
using ClassSmart.Utilities;
using Microsoft.IdentityModel.Tokens;

namespace ClassSmart.Forms
{
    /// <summary>
    /// Form for user login.
    /// </summary>
    public partial class LoginForm : Form
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            var dbContext = new ApplicationDBContext();
            var userRepository = new UserRepository(dbContext);
            var classRepository = new ClassRepository(dbContext);
            _userService = new UserService(userRepository, classRepository);
            FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
        }

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the login button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty())
            {
                errorLabel.Text = "Please fill in all fields";
                return;
            }

            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (!StringExtensions.IsValidEmail(email))
            {
                errorLabel.Text = "Please enter a valid email address.";
                return;
            }

            var teacher = _userService.LoginTeacher(email, password);

            if (teacher != null)
            {
                TeacherDashboardForm teacherDashboardForm = new TeacherDashboardForm(teacher, this);
                teacherDashboardForm.Show();
                Hide();
                textBox1.Text = "";
                textBox2.Text = "";
                errorLabel.Text = "";
            }
            else
            {
                var student = _userService.LoginStudent(email, password);

                if (student != null)
                {
                    StudentDashboardForm studentDashboardForm = new StudentDashboardForm(student, this);
                    studentDashboardForm.Show();
                    Hide();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    errorLabel.Text = "";
                }
                else
                {
                    errorLabel.Text = "Invalid login credentials.";
                }
            }
        }
    }
}
