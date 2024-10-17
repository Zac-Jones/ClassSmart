using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDBContext _context;

        public QuestionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Question> GetQuestionsByQuizId(int quizId)
        {
            using (var dbContext = new ApplicationDBContext())
            {
                return dbContext.Quizzes
                    .Where(q => q.Id == quizId)
                    .SelectMany(q => q.Questions)
                    .ToList();
            }
        }
    }

}
