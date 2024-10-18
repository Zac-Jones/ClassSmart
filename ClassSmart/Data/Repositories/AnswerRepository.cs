using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDBContext _context;

        public AnswerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            using (var dbContext = new ApplicationDBContext())
            {
                return dbContext.Questions
                    .Where(q => q.Id == questionId)
                    .SelectMany(q => q.Answers)
                    .ToList();
            }
        }

        public void Update(Answer answer)
        {
            _context.Answers.Update(answer);
            _context.SaveChanges();
        }
    }
}
