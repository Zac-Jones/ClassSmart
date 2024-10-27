using ClassSmart.Enums;

namespace ClassSmart.Models
{
    public class Question
    {
        public int Id { get; set; }
        public QuestionType Type { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public double Points { get; set; }
    }
}
