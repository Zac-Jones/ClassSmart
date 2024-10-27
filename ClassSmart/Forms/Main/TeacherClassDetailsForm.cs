using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Model;
using ClassSmart.Services;

namespace ClassSmart.Forms.Main
{
    /// <summary>
    /// Form for displaying teacher class details.
    /// </summary>
    public partial class TeacherClassDetailsForm : Form
    {
        private TeacherDashboardForm teacherDashboardForm;
        private Teacher teacher;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherClassDetailsForm"/> class.
        /// </summary>
        /// <param name="teacher">The teacher whose class details are to be displayed.</param>
        /// <param name="teacherDashboardForm">The dashboard form to return to after closing this form.</param>
        public TeacherClassDetailsForm(Teacher teacher, TeacherDashboardForm teacherDashboardForm)
        {
            this.teacher = teacher;
            this.teacherDashboardForm = teacherDashboardForm;
            InitializeComponent();

            // Display Class Information Here
            DisplayClass(teacher);
            FormClosing += new FormClosingEventHandler(TeacherClassDetailsForm_FormClosing);
        }

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void TeacherClassDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Displays the class information for the specified teacher.
        /// </summary>
        /// <param name="teacher">The teacher whose class information is to be displayed.</param>
        private void DisplayClass(Teacher teacher)
        {
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            var teacherClass = classRepository.GetClassByTeacherId(teacher.Id);

            UserService userService = new UserService(userRepository, classRepository);

            List<Student> students = userService.GetStudentsForClass(teacherClass);

            // Available Variable for checking if student objects are in <Student> Students list in class Class
            bool available = false;

            // Clear the label text before appending
            label2.Text = string.Empty;

            // Display ID of Class and Teacher
            label2.Text += "Class ID: " + Convert.ToString(teacherClass.Id) + Environment.NewLine;
            label2.Text += "Teacher ID: " + Convert.ToString(teacherClass.TeacherId) + Environment.NewLine;

            // Displays Students in each Class
            if (students == null)
            {
                label2.Text += "Error. Students has not been initialised" + Environment.NewLine;
            }
            else if (students != null)
            {
                foreach (Student student in students)
                {
                    if (student != null)
                    {
                        available = true;
                        // Append each student's name followed by a newline
                        label2.Text += "Student Name: " + student.Name + Environment.NewLine;
                    }
                }
            }

            if (available == false)
            {
                label2.Text += "There Are No Students In This Class";
            }
        }

        /// <summary>
        /// Handles the cancel button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
            teacherDashboardForm.Show();
        }
    }
}
