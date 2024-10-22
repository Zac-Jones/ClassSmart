using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassSmart.Model;
using ClassSmart.Models;

namespace ClassSmart.Forms.Main
{
    public partial class ClassDetailsForm : Form
    {
        private TeacherDashboardForm teacherDashboardForm;

        public ClassDetailsForm(Models.Class teacherClass, TeacherDashboardForm teacherDashboardForm)
        {
            this.teacherDashboardForm = teacherDashboardForm;
            InitializeComponent();
            DisplayClassDetails(teacherClass);
        }

        private void DisplayClassDetails(Models.Class teacherClass)
        {
            label1.Text = $"Class: {teacherClass.Id}";

            listBox1.Items.Clear();
            foreach (var student in teacherClass.Students)
            {
                listBox1.Items.Add(student.Name);
            }
        }

        private void CancelBtn_Click_1(object sender, EventArgs e)
        {
            teacherDashboardForm.Show();
            Hide();
            Dispose();
        }

    }
}
