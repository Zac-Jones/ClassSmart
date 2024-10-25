using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Models
{
    public class QuestionAttempt
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int QuizAttemptId { get; set; }
        public List<int> AnswerIndexes { get; set; }
        public double Score { get; set; }
    }
}
