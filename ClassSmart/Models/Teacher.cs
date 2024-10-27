using ClassSmart.Models;

namespace ClassSmart.Model
{
    public class Teacher : User
    {
        public Class Class { get; set; } = new Class();
    }
}
