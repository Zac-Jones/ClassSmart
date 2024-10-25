using ClassSmart.Data.Repositories;
using ClassSmart.Model;
using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Services
{
    public class AttemptService
    {
        private readonly IAttemptRepository _attemptRepository;

        public AttemptService(IAttemptRepository attemptRepository)
        {
            _attemptRepository = attemptRepository;
        }

        public void AddQuizAttempt(QuizAttempt quizAttempt)
        {
            _attemptRepository.AddQuizAttempt(quizAttempt);
        }

        public List<QuizAttempt> GetQuizzAttemptForStudent(long studentId)
        {
            return _attemptRepository.GetQuizAttempts(studentId);
        }

        public List<long> GetStudentIdsInQuiz(long quizId)
        {
           return _attemptRepository.GetStudentIdsInQuiz(quizId);
        }
    }
}
