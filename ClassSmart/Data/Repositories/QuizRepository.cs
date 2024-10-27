using ClassSmart.Model;
using ClassSmart.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassSmart.Data.Repositories
{
    /// <summary>
    /// Repository class for managing Quiz entities.
    /// </summary>
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public QuizRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new quiz to the database.
        /// </summary>
        /// <param name="quiz">The quiz entity to be added.</param>
        public void AddQuiz(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retrieves a quiz by its name and associated teacher.
        /// </summary>
        /// <param name="quizName">The name of the quiz.</param>
        /// <param name="teacher">The teacher associated with the quiz.</param>
        /// <returns>The quiz entity matching the specified name and teacher.</returns>
        public Quiz GetQuizByName(string quizName, Teacher teacher)
        {
            return _context.Classes
                .Where(c => c.TeacherId == teacher.Id)
                .SelectMany(c => c.Quizzes)
                .FirstOrDefault(q => q.Name == quizName);
        }

        /// <summary>
        /// Retrieves a list of quizzes associated with a specific teacher.
        /// </summary>
        /// <param name="teacher">The teacher whose quizzes are to be retrieved.</param>
        /// <returns>A list of quizzes associated with the specified teacher.</returns>
        public List<Quiz> GetQuizzesByTeacher(Teacher teacher)
        {
            return _context.Classes
                .Where(c => c.TeacherId == teacher.Id)
                .SelectMany(c => c.Quizzes)
                .ToList();
        }

        /// <summary>
        /// Deletes a quiz by its ID.
        /// </summary>
        /// <param name="quizId">The ID of the quiz to be deleted.</param>
        public void DeleteQuiz(int quizId)
        {
            var quiz = _context.Quizzes.Include(q => q.Questions).FirstOrDefault(q => q.Id == quizId);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates an existing quiz in the database.
        /// </summary>
        /// <param name="quiz">The quiz entity to be updated.</param>
        public void UpdateQuiz(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retrieves a quiz by its ID.
        /// </summary>
        /// <param name="id">The ID of the quiz.</param>
        /// <returns>The quiz entity matching the specified ID.</returns>
        public Quiz getQuizById(int id)
        {
            return _context.Quizzes
                .FirstOrDefault(q => q.Id == id);
        }
    }
}
