using ClassSmart.Forms.Quiz;
using ClassSmart.Model;
using Microsoft.IdentityModel.Tokens;

namespace ClassSmart.Forms
{
    /// <summary>
    /// Form for creating a new quiz.
    /// </summary>
    public partial class QuizCreateMainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuizCreateMainForm"/> class.
        /// </summary>
        /// <param name="teacher">The teacher creating the quiz.</param>
        /// <param name="teacherDashboardForm">The teacher dashboard form to return to after creating the quiz.</param>
        public QuizCreateMainForm(Teacher teacher, TeacherDashboardForm teacherDashboardForm)
        {
            this.teacherDashboardForm = teacherDashboardForm;
            this.teacher = teacher;
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(QuizCreateForm_FormClosing);
        }

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void QuizCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the add questions button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void addQuestionsBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IsNullOrEmpty())
            {
                errorLabel.Text = "Please fill in all fields";
                return;
            }

            if (dateTimePicker1.Value < DateTime.Now)
            {
                errorLabel.Text = "Please select a valid start date";
                return;
            }

            if (dateTimePicker2.Value < DateTime.Now)
            {
                errorLabel.Text = "Please select a valid end date";
                return;
            }

            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                errorLabel.Text = "End date must be after start date";
                return;
            }

            if (numericUpDown2.Value == 0)
            {
                errorLabel.Text = "Please select a valid amount of questions";
                return;
            }

            if (numericUpDown3.Value == 0)
            {
                errorLabel.Text = "Please select a valid test weight";
                return;
            }

            errorLabel.Text = "";

            Models.Quiz quiz = new Models.Quiz();
            quiz.Name = textBox1.Text;
            quiz.StartTime = dateTimePicker1.Value;
            quiz.EndTime = dateTimePicker2.Value;
            quiz.TotalPoints = (double)numericUpDown3.Value;

            QuizCreateQuestionsForm quizCreateQuestionsForm = new QuizCreateQuestionsForm(teacher, teacherDashboardForm, this, quiz, (int)numericUpDown2.Value);
            quizCreateQuestionsForm.Show();
            Hide();
        }

        /// <summary>
        /// Handles the cancel button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            teacherDashboardForm.Show();
            Hide();
            Dispose();
        }
    }
}
