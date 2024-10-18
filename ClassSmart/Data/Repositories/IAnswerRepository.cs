using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public interface IAnswerRepository
    {
        List<Answer> GetAnswersByQuestionId(int questionId);
        void Update(Answer answer);
    }
}
