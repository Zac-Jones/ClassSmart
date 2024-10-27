using ClassSmart.Models;

namespace ClassSmart.Data.Repositories
{
    public interface IAnswerRepository
    {
        List<Answer> GetAnswersByQuestionId(int questionId);
        void Update(Answer answer);
    }
}
