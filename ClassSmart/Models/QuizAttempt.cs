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
