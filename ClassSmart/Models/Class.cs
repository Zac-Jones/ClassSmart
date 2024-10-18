using ClassSmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Models
{
    public class Class
    {
        public int Id { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
