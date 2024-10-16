using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public double TotalPoints { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
