using ClassSmart.Model;
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

        public List<QuizAttempt> GetQuizAttempts(long studentId)
        {
            return _context.QuizAttempts.Where(q => q.StudentId == studentId).ToList(); ;
        }

        public List<long> GetStudentIdsInQuiz(long quizId)
        {
            return _context.QuizAttempts
                .Where(q => q.QuizId == quizId)
                .Select(q => (long)q.StudentId)
                .Distinct()
                .ToList();
        }
    }
}
