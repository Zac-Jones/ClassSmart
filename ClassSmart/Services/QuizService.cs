using ClassSmart.Data.Repositories;
using ClassSmart.Model;
using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Services
{
    public class QuizService
    {
        private readonly IClassRepository _classRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IUserRepository _userRepository;

        public QuizService(
            IClassRepository classRepository,
            IQuizRepository quizRepository,
            IUserRepository userRepository)
        {
            _classRepository = classRepository;
            _quizRepository = quizRepository;
            _userRepository = userRepository;
        }

        public void CreateQuizForTeacher(Teacher teacher, Quiz quiz)
        {
            var existingClass = _classRepository.GetClassByTeacherId(teacher.Id);

            if (existingClass == null)
            {
                existingClass = new Class
                {
                    TeacherId = teacher.Id,
                    Teacher = teacher,
                    Students = new List<Student>()
                };
                _classRepository.AddClass(existingClass);
            }

            existingClass.Quizzes.Add(quiz);
            teacher.Class = existingClass;

            _userRepository.UpdateTeacher(teacher);
            _quizRepository.AddQuiz(quiz);
        }
    }
}