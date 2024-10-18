using ClassSmart.Model;
using ClassSmart.Models;
using Microsoft.EntityFrameworkCore;
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
            _context.SaveChanges();
        }

        public Quiz GetQuizByName(string quizName, Teacher teacher)
        {
            return _context.Classes
                .Where(c => c.TeacherId == teacher.Id)
                .SelectMany(c => c.Quizzes)
                .FirstOrDefault(q => q.Name == quizName);
        }

        public List<Quiz> GetQuizzesByTeacher(Teacher teacher)
        {
            return _context.Classes
                .Where(c => c.TeacherId == teacher.Id)
                .SelectMany(c => c.Quizzes)
                .ToList();
        }

        public void DeleteQuiz(int quizId)
        {
            var quiz = _context.Quizzes.Include(q => q.Questions).FirstOrDefault(q => q.Id == quizId);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                _context.SaveChanges();
            }
        }

        public void UpdateQuiz(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            _context.SaveChanges();
        }
    }
}
