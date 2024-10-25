using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Models
{
    public class QuizAttempt
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public double Score { get; set; }
        public List<QuestionAttempt> QuestionAttempts { get; set; }
    }
}
