using ClassSmart.Model;
using ClassSmart.Models;

namespace ClassSmart.Services
{
    public interface IQuizService
    {
        void CreateQuizForTeacher(Teacher teacher, Quiz quiz);
        Quiz GetQuizByName(string quizName, Teacher teacher);
        List<Quiz> GetQuizzesByTeacher(Teacher teacher);
        Quiz GetQuizById(int id);
        void DeleteQuiz(int quizId);
        void UpdateQuiz(Quiz quiz);
    }
}
