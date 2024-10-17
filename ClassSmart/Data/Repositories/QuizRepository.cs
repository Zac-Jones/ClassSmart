using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDBContext _context;

        public QuizRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddQuiz(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
        }
    }
}
