using ClassSmart.Models;

namespace ClassSmart.Data.Repositories
{
    /// <summary>
    /// Repository class for managing Question entities.
    /// </summary>
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public QuestionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of questions associated with a specific quiz ID.
        /// </summary>
        /// <param name="quizId">The ID of the quiz.</param>
        /// <returns>A list of questions associated with the specified quiz ID.</returns>
        public List<Question> GetQuestionsByQuizId(int quizId)
        {
            using (var dbContext = new ApplicationDBContext())
            {
                return dbContext.Quizzes
                    .Where(q => q.Id == quizId)
                    .SelectMany(q => q.Questions)
                    .ToList();
            }
        }

        /// <summary>
        /// Updates an existing question in the database.
        /// </summary>
        /// <param name="question">The question entity to be updated.</param>
        public void Update(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }
    }
}
