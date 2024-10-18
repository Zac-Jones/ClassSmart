using ClassSmart.Data.Repositories;
using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Services
{
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public List<Question> GetQuestionsByQuizId(int quizId)
        {
            return _questionRepository.GetQuestionsByQuizId(quizId);
        }

        public void UpdateQuestion(Question question)
        {
            _questionRepository.Update(question);
        }
    }

}
