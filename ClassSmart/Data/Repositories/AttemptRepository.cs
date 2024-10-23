using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public class AttemptRepository : IAttemptRepository
    {
        private readonly ApplicationDBContext _context;

        public AttemptRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddQuizAttempt(QuizAttempt quizAttempt)
        {
            _context.QuizAttempts.Add(quizAttempt);
            _context.SaveChanges();
        }
    }
}
