using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassSmart.Data.Repositories;
using ClassSmart.Data;
using ClassSmart.Model;
using ClassSmart.Services;

namespace ClassSmart.Forms.Main
{
    public partial class TeacherAnalyticsForm : Form
    {
        private TeacherDashboardForm teacherDashboardForm;

        public TeacherAnalyticsForm(Teacher teacher, TeacherDashboardForm teacherDashboardForm)
        {
            this.teacherDashboardForm = teacherDashboardForm;
            InitializeComponent();
            DisplayClassDetails(teacher);
        }

        private void TeacherAnalyticsForm_Load(object sender, EventArgs e)
        {
        }

        private void DisplayClassDetails(Teacher teacher)
        {
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            var teacherClass = classRepository.GetClassByTeacherId(teacher.Id);

            UserService userService = new UserService(userRepository, classRepository);

            List<Student> students = userService.GetStudentsForClass(teacherClass);

            //Available Variable for checking if student objects are in <Student> Students list in class Class
            bool available = false;


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

        private void button1_Click(object sender, EventArgs e)
        {
            teacherDashboardForm.Show();
            Hide();
            Dispose();
        }
    }
}
