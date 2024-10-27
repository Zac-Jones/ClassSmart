using ClassSmart.Data.Repositories;
using ClassSmart.Models;

namespace ClassSmart.Services
{
    /// <summary>
    /// Service class for managing questions.
    /// </summary>
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionService"/> class.
        /// </summary>
        /// <param name="questionRepository">The question repository.</param>
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        /// <summary>
        /// Gets the questions by quiz identifier.
        /// </summary>
        /// <param name="quizId">The quiz identifier.</param>
        /// <returns>A list of questions associated with the specified quiz identifier.</returns>
        public List<Question> GetQuestionsByQuizId(int quizId)
        {
            return _questionRepository.GetQuestionsByQuizId(quizId);
        }

        /// <summary>
        /// Updates the specified question.
        /// </summary>
        /// <param name="question">The question to update.</param>
        public void UpdateQuestion(Question question)
        {
            _questionRepository.Update(question);
        }
    }
}
