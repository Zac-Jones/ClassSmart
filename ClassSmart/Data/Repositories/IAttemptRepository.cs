using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public interface IAttemptRepository
    {
        void AddQuizAttempt(QuizAttempt quizAttempt);
        List<QuizAttempt> GetQuizAttempts(long studentId);
    }

   
}
