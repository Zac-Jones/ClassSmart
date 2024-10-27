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
