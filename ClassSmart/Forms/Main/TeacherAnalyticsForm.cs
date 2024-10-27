using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Model;
using ClassSmart.Services;

namespace ClassSmart.Forms.Main
{
    /// <summary>
    /// Form for displaying teacher analytics.
    /// </summary>
    public partial class TeacherAnalyticsForm : Form
    {
        private TeacherDashboardForm teacherDashboardForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherAnalyticsForm"/> class.
        /// </summary>
        /// <param name="teacher">The teacher whose analytics are to be displayed.</param>
        /// <param name="teacherDashboardForm">The dashboard form to return to after closing this form.</param>
        public TeacherAnalyticsForm(Teacher teacher, TeacherDashboardForm teacherDashboardForm)
        {
            this.teacherDashboardForm = teacherDashboardForm;
            InitializeComponent();
            DisplayClassDetails(teacher);
            FormClosing += new FormClosingEventHandler(TeacherAnalyticsForm_FormClosing);
        }

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TeacherAnalyticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TeacherAnalyticsForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Displays the class details for the specified teacher.
        /// </summary>
        /// <param name="teacher">The teacher whose class details are to be displayed.</param>
        private void DisplayClassDetails(Teacher teacher)
        {
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            var teacherClass = classRepository.GetClassByTeacherId(teacher.Id);

            UserService userService = new UserService(userRepository, classRepository);

            List<Student> students = userService.GetStudentsForClass(teacherClass);

            int buttonHeight = 30;
            int buttonSpacing = 10;

            foreach (Student student in students)
            {
                Button studentButton = new Button
                {
                    Text = student.Name,
                    Location = new Point(10, (buttonHeight + buttonSpacing) + 10),
                    Size = new Size(200, buttonHeight)
                };

                studentButton.Click += (sender, e) =>
                {
                    StudentAnalyticsForm studentAnalyticsForm = new StudentAnalyticsForm(student, this);
                    studentAnalyticsForm.Show();
                    this.Hide();
                };

                this.Controls.Add(studentButton);
            }
        }

        /// <summary>
        /// Handles the back button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            teacherDashboardForm.Show();
            Hide();
            Dispose();
        }
    }
}
