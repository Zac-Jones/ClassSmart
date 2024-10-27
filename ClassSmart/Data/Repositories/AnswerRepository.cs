using ClassSmart.Models;

namespace ClassSmart.Data.Repositories
{
    /// <summary>
    /// Repository class for managing Answer entities.
    /// </summary>
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public AnswerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of answers associated with a specific question ID.
        /// </summary>
        /// <param name="questionId">The ID of the question.</param>
        /// <returns>A list of answers associated with the specified question ID.</returns>
        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            using (var dbContext = new ApplicationDBContext())
            {
                return dbContext.Questions
                    .Where(q => q.Id == questionId)
                    .SelectMany(q => q.Answers)
                    .ToList();
            }
        }

        /// <summary>
        /// Updates an existing answer in the database.
        /// </summary>
        /// <param name="answer">The answer entity to be updated.</param>
        public void Update(Answer answer)
        {
            _context.Answers.Update(answer);
            _context.SaveChanges();
        }
    }
}
