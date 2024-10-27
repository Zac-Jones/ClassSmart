namespace ClassSmart.Forms.Main
{
    /// <summary>
    /// Form for displaying the details of a class.
    /// </summary>
    public partial class ClassDetailsForm : Form
    {
        private TeacherDashboardForm teacherDashboardForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassDetailsForm"/> class.
        /// </summary>
        /// <param name="teacherClass">The class to display details for.</param>
        /// <param name="teacherDashboardForm">The parent dashboard form.</param>
        public ClassDetailsForm(Models.Class teacherClass, TeacherDashboardForm teacherDashboardForm)
        {
            this.teacherDashboardForm = teacherDashboardForm;
            InitializeComponent();
            DisplayClassDetails(teacherClass);
        }

        /// <summary>
        /// Displays the details of the specified class.
        /// </summary>
        /// <param name="teacherClass">The class whose details are to be displayed.</param>
        private void DisplayClassDetails(Models.Class teacherClass)
        {
            label1.Text = $"Class: {teacherClass.Id}";

            listBox1.Items.Clear();
            foreach (var student in teacherClass.Students)
            {
                listBox1.Items.Add(student.Name);
            }
        }

        /// <summary>
        /// Handles the Cancel button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void CancelBtn_Click_1(object sender, EventArgs e)
        {
            teacherDashboardForm.Show();
            Hide();
            Dispose();
        }
    }
}
