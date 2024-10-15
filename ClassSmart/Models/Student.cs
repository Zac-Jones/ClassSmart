using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Model
{
    internal class Student : User
    {
        public List<Class> Classes { get; set; } = new List<Class>();
    }
}
