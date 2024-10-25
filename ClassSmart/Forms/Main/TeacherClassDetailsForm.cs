using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;

namespace ClassSmart.Forms.Main
{
    public partial class TeacherClassDetailsForm : Form
    {
        private TeacherDashboardForm teacherDashboardForm;
        private Teacher teacher;

        public TeacherClassDetailsForm(Teacher teacher, TeacherDashboardForm teacherDashboardForm)
        {
            this.teacher = teacher;
            this.teacherDashboardForm = teacherDashboardForm;
            InitializeComponent();

            //Display Class Information Here
            DisplayClass(teacher);
            FormClosing += new FormClosingEventHandler(TeacherClassDetailsForm_FormClosing);
        }

        private void TeacherClassDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Method to Display Class Information
        private void DisplayClass(Teacher teacher)
        {
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            var teacherClass = classRepository.GetClassByTeacherId(teacher.Id);

            UserService userService = new UserService(userRepository, classRepository);

            List<Student> students = userService.GetStudentsForClass(teacherClass);

            //Available Variable for checking if student objects are in <Student> Students list in class Class
            bool available = false;



            // Clear the label text before appending
            label2.Text = string.Empty;

            //Display ID of Class and Teacher
            label2.Text += "Class ID: " + Convert.ToString(teacherClass.Id) + Environment.NewLine;
            label2.Text += "Teacher ID: " + Convert.ToString(teacherClass.TeacherId) + Environment.NewLine;

            //Displays Students in each Class
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

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are You Sure You Want To Cancel?",
                "Confirm Cancel",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                teacherDashboardForm.Show();
                Hide();
                Dispose();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TeacherClassDetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
