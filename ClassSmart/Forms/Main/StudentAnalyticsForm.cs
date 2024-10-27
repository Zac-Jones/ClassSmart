using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClassSmart.Forms.Main
{
    /// <summary>
    /// Form for displaying student analytics.
    /// </summary>
    public partial class StudentAnalyticsForm : Form
    {
        private Form returnForm1;
        private Student student;
        private Chart chart = new Chart
        {
            Width = 678,
            Height = 272,
            Location = new Point(101, 252)
        };

        private Series series = new Series("Student Analytics")
        {
            ChartType = SeriesChartType.Column
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentAnalyticsForm"/> class.
        /// </summary>
        /// <param name="student">The student whose analytics are to be displayed.</param>
        /// <param name="returnForm">The form to return to after closing this form.</param>
        public StudentAnalyticsForm(Student student, Form returnForm)
        {
            InitializeComponent();
            this.student = student;
            returnForm1 = returnForm;
            Console.WriteLine("StudentAnalyticsForm initialized.");
            InitializeChart();
            DisplayClass(student);
            FormClosing += new FormClosingEventHandler(StudentAnalyticsForm_FormClosing);
        }

        /// <summary>
        /// Handles the form closing event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void StudentAnalyticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Initializes the chart for displaying analytics.
        /// </summary>
        private void InitializeChart()
        {
            // Add a chart area
            ChartArea chartArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(chartArea);

            // Add chart to form controls
            Controls.Add(chart);
            chart.BringToFront();
        }

        /// <summary>
        /// Populates the chart with data.
        /// </summary>
        /// <param name="userPercentage">The user's percentage score.</param>
        /// <param name="classPercentage">The class's average percentage score.</param>
        /// <param name="quizId">The ID of the quiz.</param>
        private void PopulateChart(double userPercentage, double classPercentage, int quizId)
        {
            // Add points
            series.Points.AddXY($"{student.Name} - Quiz #" + quizId, userPercentage);
            series.Points.AddXY("Class Average - Quiz #" + quizId, classPercentage);
        }

        /// <summary>
        /// Displays the class analytics for the specified student.
        /// </summary>
        /// <param name="student">The student whose class analytics are to be displayed.</param>
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

            List<double> classPercentages = new List<double>();
            List<double> userPercentages = new List<double>();

            List<QuizAttempt> quizAttempts = attemptService.GetQuizzAttemptForStudent(student.Id);

            foreach (var attempt in quizAttempts)
            {
                var quiz = quizService.GetQuizById(attempt.Id);
                if (quiz != null)
                {
                    double userPercentage = GeneratePercentageDisplay(attempt.Score, quiz.TotalPoints);
                    userPercentages.Add(userPercentage);

                    var classAverage = GetClassQuizAverage(student.Id, quiz.Id);
                    double classPercentage = GeneratePercentageDisplay(classAverage, quiz.TotalPoints);
                    classPercentages.Add(classPercentage);

                    dataGridView1.Rows.Add(quiz.Name, $"{Math.Round(attempt.Score, 2)}/{quiz.TotalPoints}", (userPercentage.ToString("F2") + "%"), $"{Math.Round(classAverage, 2)}/{quiz.TotalPoints}", (classPercentage.ToString("F2") + "%"));

                    PopulateChart(userPercentage, classPercentage, quiz.Id);
                }
            }

            // Add series to the chart
            chart.Series.Add(series);
        }

        /// <summary>
        /// Gets the class average score for a specific quiz.
        /// </summary>
        /// <param name="studentID">The ID of the student.</param>
        /// <param name="quizID">The ID of the quiz.</param>
        /// <returns>The class average score for the quiz.</returns>
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

        /// <summary>
        /// Generates a percentage display for a given score and total.
        /// </summary>
        /// <param name="score">The score obtained.</param>
        /// <param name="total">The total possible score.</param>
        /// <returns>The percentage score.</returns>
        private double GeneratePercentageDisplay(double score, double total)
        {
            if (total == 0)
            {
                return 0;
            }

            double percentage = Math.Round((score / total) * 100, 2);
            return Math.Min(percentage, 100);
        }

        /// <summary>
        /// Handles the back button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            returnForm1.Show();
            Hide();
            Dispose();
        }
    }
}
