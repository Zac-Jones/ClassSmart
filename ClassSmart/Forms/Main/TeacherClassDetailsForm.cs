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
            
            //Add label1 Text (Title)
            label1.Text = string.Empty;
            label1.Text += "Class Details";

            //Display Class Information Here
            DisplayClass(teacher);
        }

        //Method to Display Class Information
        private void DisplayClass(Teacher teacher)
        {
            ClassRepository cR = new ClassRepository(new ApplicationDBContext());
            var teacherClass = cR.GetClassByTeacherId(teacher.Id);
            List<Student> students = teacherClass.Students;
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
    }
}
