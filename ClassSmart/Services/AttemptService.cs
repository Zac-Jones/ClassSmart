using ClassSmart.Data.Repositories;
using ClassSmart.Models;

namespace ClassSmart.Services
{
    /// <summary>
    /// Service class for managing quiz attempts.
    /// </summary>
    public class AttemptService
    {
        private readonly IAttemptRepository _attemptRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttemptService"/> class.
        /// </summary>
        /// <param name="attemptRepository">The attempt repository.</param>
        public AttemptService(IAttemptRepository attemptRepository)
        {
            _attemptRepository = attemptRepository;
        }

        /// <summary>
        /// Adds a new quiz attempt.
        /// </summary>
        /// <param name="quizAttempt">The quiz attempt to add.</param>
        public void AddQuizAttempt(QuizAttempt quizAttempt)
        {
            _attemptRepository.AddQuizAttempt(quizAttempt);
        }

        /// <summary>
        /// Gets the quiz attempts for a specific student.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>A list of quiz attempts associated with the specified student identifier.</returns>
        public List<QuizAttempt> GetQuizzAttemptForStudent(long studentId)
        {
            return _attemptRepository.GetQuizAttempts(studentId);
        }

        /// <summary>
        /// Gets the student identifiers for a specific quiz.
        /// </summary>
        /// <param name="quizId">The quiz identifier.</param>
        /// <returns>A list of student identifiers associated with the specified quiz identifier.</returns>
        public List<long> GetStudentIdsInQuiz(long quizId)
        {
            return _attemptRepository.GetStudentIdsInQuiz(quizId);
        }
    }
}
