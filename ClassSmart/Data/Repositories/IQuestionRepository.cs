using ClassSmart.Models;

namespace ClassSmart.Data.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestionsByQuizId(int quizId);
        void Update(Question question);
    }
}
