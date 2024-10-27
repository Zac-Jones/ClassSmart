using ClassSmart.Models;

namespace ClassSmart.Model
{
    public class Student : User
    {
        public List<Class> Classes { get; set; } = new List<Class>();
    }
}
