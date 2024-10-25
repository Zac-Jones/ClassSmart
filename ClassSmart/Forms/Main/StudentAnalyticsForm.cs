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
    public partial class StudentAnalyticsForm : Form
    {
        private Form returnForm1;

        public StudentAnalyticsForm(Student student, Form returnForm)
        {
            InitializeComponent();
            returnForm1 = returnForm;
            Console.WriteLine("StudentAnalyticsForm initialized.");
            DisplayClass(student);
        }

        private void DisplayClass(Student student)
        {
            // Attempt Service
            AttemptRepository attemptRepository = new AttemptRepository(new ApplicationDBContext());
            AttemptService attemptService = new AttemptService(attemptRepository);

            // Quiz Service 
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            QuizRepository quizRepository = new QuizRepository(new ApplicationDBContext());
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());
            QuizService quizService = new QuizService(classRepository, quizRepository, userRepository);

            List<QuizAttempt> quizAttempts = attemptService.GetQuizzAttemptForStudent(student.Id);

            foreach (var attempt in quizAttempts)
            {
                var quiz = quizService.GetQuizById(attempt.Id);
                if (quiz != null)
                {
                    string percentageDisplay = GeneratePercentageDisplay(attempt.Score, quiz.TotalPoints);

                    var classAverage = GetClassQuizAverage(student.Id, quiz.Id);
                    var classPercentage = GeneratePercentageDisplay(classAverage, quiz.TotalPoints);

                    dataGridView1.Rows.Add(quiz.Name, $"{Math.Round(attempt.Score, 2)}/{quiz.TotalPoints}", percentageDisplay, $"{Math.Round(classAverage, 2)}/{quiz.TotalPoints}", classPercentage);
                }
            }
        }

        private double GetClassQuizAverage(int studentID, long quizID)
        {
            // Attempt Service
            AttemptRepository attemptRepository = new AttemptRepository(new ApplicationDBContext());
            AttemptService attemptService = new AttemptService(attemptRepository);

            // User Service
            UserRepository userRepository = new UserRepository(new ApplicationDBContext());
            ClassRepository classRepository = new ClassRepository(new ApplicationDBContext());
            UserService userService = new UserService(userRepository, classRepository);

            List<long> studentIds = attemptService.GetStudentIdsInQuiz(quizID);
            List<Student> students = new List<Student>();
            List<QuizAttempt> classQuizAttempts = new List<QuizAttempt>();

            foreach (var id in studentIds)
            {
                students.Add(userService.GetStudentFromId(id));
            }

            foreach (var student in students)
            {
                List<QuizAttempt> quizAttempts = attemptRepository.GetQuizAttempts(student.Id);

                foreach (var quizAttempt in quizAttempts)
                {
                    if (quizAttempt.QuizId == quizID)
                    {
                        classQuizAttempts.Add(quizAttempt);
                    }
                }
            }
            if (classQuizAttempts.Count > 0)
            {
                double totalScore = classQuizAttempts.Sum(attempt => attempt.Score);
                return Math.Round(totalScore / classQuizAttempts.Count, 2);
            }
            return 0;
        }

        private string GeneratePercentageDisplay(double score, double total)
        {
            string percentageDisplay;

            if (score == 0)
            {
                percentageDisplay = "0%";
            }
            else
            {
                var percentage = Math.Round((score / total) * 100, 2);
                if (percentage > 100)
                {
                    percentage = 100;
                }
                percentageDisplay = percentage.ToString("F2") + "%";
            }
            return percentageDisplay;
        }

        private void StudentAnalyticsForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnForm1.Show();
            Hide();
            Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
