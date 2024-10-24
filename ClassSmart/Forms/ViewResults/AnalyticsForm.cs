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
using ClassSmart.Services;
using Microsoft.EntityFrameworkCore;

namespace ClassSmart.Forms.Main
{
    public partial class AnalyticsForm : Form
    {
        public AnalyticsForm(Student student)   
        {
            var dbContext = new ApplicationDBContext();
            var classRepository = new ClassRepository(dbContext);
            var quizRepository = new QuizRepository(dbContext);
            var userRepository = new UserRepository(dbContext);
            this.student = student;

            _quizService = new QuizService(classRepository, quizRepository, userRepository);
            InitializeComponent();
            LoadQuizzes();
        }

        private void LoadQuizzes()
        {
            quizzes = _quizService.GetQuizzesByStudent(student);

            listBox1.Items.Clear();

            foreach (var quiz in quizzes)
            {
                listBox1.Items.Add(quiz.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
