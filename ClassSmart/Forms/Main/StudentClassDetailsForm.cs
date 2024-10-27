using ClassSmart.Forms.Class;
using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Model;
using ClassSmart.Services;

namespace ClassSmart.Forms.Main
{
    /// <summary>
    /// Form for displaying student class details.
    /// </summary>
    public partial class StudentClassDetailsForm : Form
    {
        StudentDashboardForm studentDashboardForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentClassDetailsForm"/> class.
        /// </summary>
        /// <param name="student">The student whose class details are to be displayed.</param>
        /// <param name="studentDashboardForm">The dashboard form to return to after closing this form.</param>
        public StudentClassDetailsForm(Student student, StudentDashboardForm studentDashboardForm)
        {
            this.studentDashboardForm = studentDashboardForm;
            InitializeComponent();
            DisplayClass(student);

            FormClosing += new FormClosingEventHandler(StudentClassDetailsForm_FormClosing);
        }

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void StudentClassDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Displays the class information for the specified student.
        /// </summary>
        /// <param name="student">The student whose class information is to be displayed.</param>
        private void DisplayClass(Student student)
        {
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());

            UserService userService = new UserService(userRepository, classRepository);
            List<Models.Class> classes = userService.GetClassesForStudent(student);
            int i = 50;

            foreach (Models.Class c in classes)
            {
                // Generate a new button
                Button newButton = new Button();
                newButton.Text = "Class ID: " + c.Id;
                var size = new Size(100, 50);
                newButton.Size = size; // Set the size of the button
                newButton.Location = new System.Drawing.Point((Width / 2) - (size.Width / 2), i); // Set the location on the form
                newButton.Click += (sender, e) => NewButton_Click(sender, e, c);
                newButton.BringToFront();
                Controls.Add(newButton);

                i += 50;
            }
        }

        /// <summary>
        /// Handles the click event for the dynamically generated class buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        /// <param name="c">The class associated with the clicked button.</param>
        private void NewButton_Click(object sender, EventArgs e, Models.Class c)
        {
            ClassViewQuizzesForm classViewQuizzesForm = new ClassViewQuizzesForm(c, this, studentDashboardForm);
            classViewQuizzesForm.Show();
            Hide();
        }

        /// <summary>
        /// Handles the cancel button click event.
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
