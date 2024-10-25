using ClassSmart.Model;
using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public interface IQuizRepository
    {
        void AddQuiz(Quiz quiz);
        Quiz GetQuizByName(string quizName, Teacher teacher);
        List<Quiz> GetQuizzesByTeacher(Teacher teacher);
        void DeleteQuiz(int quizId);
        void UpdateQuiz(Quiz quiz);
        Quiz getQuizById(int id);
    }
}
