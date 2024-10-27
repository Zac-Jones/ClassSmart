using ClassSmart.Models;

namespace ClassSmart.Data.Repositories
{
    /// <summary>
    /// Repository class for managing QuizAttempt entities.
    /// </summary>
    public class AttemptRepository : IAttemptRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttemptRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public AttemptRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new quiz attempt to the database.
        /// </summary>
        /// <param name="quizAttempt">The quiz attempt entity to be added.</param>
        public void AddQuizAttempt(QuizAttempt quizAttempt)
        {
            _context.QuizAttempts.Add(quizAttempt);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retrieves a list of quiz attempts for a specific student.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>A list of quiz attempts associated with the specified student ID.</returns>
        public List<QuizAttempt> GetQuizAttempts(long studentId)
        {
            return _context.QuizAttempts.Where(q => q.StudentId == studentId).ToList();
        }

        /// <summary>
        /// Retrieves a list of student IDs who have attempted a specific quiz.
        /// </summary>
        /// <param name="quizId">The ID of the quiz.</param>
        /// <returns>A list of student IDs who have attempted the specified quiz.</returns>
        public List<long> GetStudentIdsInQuiz(long quizId)
        {
            return _context.QuizAttempts
                .Where(q => q.QuizId == quizId)
                .Select(q => (long)q.StudentId)
                .Distinct()
                .ToList();
        }
    }
}
