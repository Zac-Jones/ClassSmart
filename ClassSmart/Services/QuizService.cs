using ClassSmart.Data.Repositories;  
using ClassSmart.Model;  
using ClassSmart.Models;  

namespace ClassSmart.Services  
{  
    /// <summary>  
    /// Service class for managing quizzes.  
    /// </summary>  
    public class QuizService : IQuizService  
    {  
        private readonly IClassRepository _classRepository;  
        private readonly IQuizRepository _quizRepository;  
        private readonly IUserRepository _userRepository;  

        /// <summary>  
        /// Initializes a new instance of the <see cref="QuizService"/> class.  
        /// </summary>  
        /// <param name="classRepository">The class repository.</param>  
        /// <param name="quizRepository">The quiz repository.</param>  
        /// <param name="userRepository">The user repository.</param>  
        public QuizService(  
            IClassRepository classRepository,  
            IQuizRepository quizRepository,  
            IUserRepository userRepository)  
        {  
            _classRepository = classRepository;  
            _quizRepository = quizRepository;  
            _userRepository = userRepository;  
        }  

        /// <summary>  
        /// Creates a quiz for a specific teacher.  
        /// </summary>  
        /// <param name="teacher">The teacher.</param>  
        /// <param name="quiz">The quiz to create.</param>  
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
        }  

        /// <summary>  
        /// Gets a quiz by its name and associated teacher.  
        /// </summary>  
        /// <param name="quizName">The name of the quiz.</param>  
        /// <param name="teacher">The teacher associated with the quiz.</param>  
        /// <returns>The quiz with the specified name and teacher.</returns>  
        public Quiz GetQuizByName(string quizName, Teacher teacher)  
        {  
            return _quizRepository.GetQuizByName(quizName, teacher);  
        }  

        /// <summary>  
        /// Gets the quizzes associated with a specific teacher.  
        /// </summary>  
        /// <param name="teacher">The teacher.</param>  
        /// <returns>A list of quizzes associated with the specified teacher.</returns>  
        public List<Quiz> GetQuizzesByTeacher(Teacher teacher)  
        {  
            return _quizRepository.GetQuizzesByTeacher(teacher);  
        }  

        /// <summary>  
        /// Gets a quiz by its identifier.  
        /// </summary>  
        /// <param name="id">The quiz identifier.</param>  
        /// <returns>The quiz with the specified identifier.</returns>  
        public Quiz GetQuizById(int id)  
        {  
            return _quizRepository.getQuizById(id);  
        }  

        /// <summary>  
        /// Deletes a quiz by its identifier.  
        /// </summary>  
        /// <param name="quizId">The quiz identifier.</param>  
        public void DeleteQuiz(int quizId)  
        {  
            _quizRepository.DeleteQuiz(quizId);  
        }  

        /// <summary>  
        /// Updates the specified quiz.  
        /// </summary>  
        /// <param name="quiz">The quiz to update.</param>  
        public void UpdateQuiz(Quiz quiz)  
        {  
            _quizRepository.UpdateQuiz(quiz);  
        }  
    }  
}  
