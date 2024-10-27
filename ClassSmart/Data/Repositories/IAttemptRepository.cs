using ClassSmart.Models;

namespace ClassSmart.Data.Repositories
{
    public interface IAttemptRepository
    {
        void AddQuizAttempt(QuizAttempt quizAttempt);
        List<QuizAttempt> GetQuizAttempts(long studentId);
        List<long> GetStudentIdsInQuiz(long quizId);
    }
}
