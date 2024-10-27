using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Models;
using ClassSmart.Services;

namespace ClassSmart.Utilities
{
    /// <summary>  
    /// Utility class for populating tables with initial data.  
    /// </summary>  
    public class PopulateTables
    {
        /// <summary>  
        /// Initializes the tables with default data.  
        /// </summary>  
        public static void Init()
        {
            var dbContext = new ApplicationDBContext();
            var userRepository = new UserRepository(dbContext);
            var classRepository = new ClassRepository(dbContext);
            var quizRepository = new QuizRepository(dbContext);
            var userService = new UserService(userRepository, classRepository);
            var quizService = new QuizService(classRepository, quizRepository, userRepository);

            var teacher = userService.InsertTeacher("Test Teacher", "test@teacher.com", "password");
            var student = userService.InsertStudent("John Doe", "john@doe.com", "password");

            if (quizService.GetQuizzesByTeacher(teacher).Count() == 0)
            {
                List<Answer> answerList = new List<Answer>();
                answerList.Add(new Answer { Text = "Answer 1", IsCorrect = true });
                answerList.Add(new Answer { Text = "Answer 2", IsCorrect = false });
                answerList.Add(new Answer { Text = "Answer 3", IsCorrect = false });
                answerList.Add(new Answer { Text = "Answer 4", IsCorrect = false });

                var quiz = new Quiz
                {
                    Name = "Test Quiz",
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "Question 1",
                            Answers = answerList,
                            Type = Enums.QuestionType.MultipleChoice
                        }
                    }
                };

                quizService.CreateQuizForTeacher(teacher, quiz);

                userService.AssignClassToTeacherAndStudent(teacher, student);

                dbContext.SaveChanges();
            }
        }

        /// <summary>  
        /// Initializes the tables with default data for testing purposes.  
        /// </summary>  
        /// <param name="userService">The user service.</param>  
        /// <param name="quizService">The quiz service.</param>  
        public static void InitTests(IUserService userService, IQuizService quizService)
        {
            var teacher = userService.InsertTeacher("Test Teacher", "test@teacher.com", "password");
            var student = userService.InsertStudent("John Doe", "john@doe.com", "password");

            if (quizService.GetQuizzesByTeacher(teacher).Count() == 0)
            {
                List<Answer> answerList = new List<Answer>
                {
                    new Answer { Text = "Answer 1", IsCorrect = true },
                    new Answer { Text = "Answer 2", IsCorrect = false },
                    new Answer { Text = "Answer 3", IsCorrect = false },
                    new Answer { Text = "Answer 4", IsCorrect = false }
                };

                var quiz = new Quiz
                {
                    Name = "Test Quiz",
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "Question 1",
                            Answers = answerList,
                            Type = Enums.QuestionType.MultipleChoice
                        }
                    }
                };

                quizService.CreateQuizForTeacher(teacher, quiz);

                userService.AssignClassToTeacherAndStudent(teacher, student);
            }
        }
    }
}
