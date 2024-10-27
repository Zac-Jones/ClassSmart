using ClassSmart.Data.Repositories;
using ClassSmart.Models;

namespace ClassSmart.Services
{
    /// <summary>
    /// Service class for managing answers.
    /// </summary>
    public class AnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerService"/> class.
        /// </summary>
        /// <param name="answerRepository">The answer repository.</param>
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        /// <summary>
        /// Gets the answers by question identifier.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        /// <returns>A list of answers associated with the specified question identifier.</returns>
        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            return _answerRepository.GetAnswersByQuestionId(questionId);
        }

        /// <summary>
        /// Updates the specified answer.
        /// </summary>
        /// <param name="answer">The answer to update.</param>
        public void UpdateAnswer(Answer answer)
        {
            _answerRepository.Update(answer);
        }
    }
}
