using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestionsByQuizId(int quizId);
        void Update(Question question);
    }
}
