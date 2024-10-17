using ClassSmart.Data.Repositories;
using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Services
{
    public class AnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            return _answerRepository.GetAnswersByQuestionId(questionId);
        }
    }
}
