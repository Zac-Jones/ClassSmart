using ClassSmart.Data.Repositories;
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
    }
}
