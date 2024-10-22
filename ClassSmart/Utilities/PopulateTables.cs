using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Forms.Main;
using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;
using System;
using System.Linq;

namespace ClassSmart.Utilities
{
    public class PopulateTables
    {
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
}
