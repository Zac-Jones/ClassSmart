using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Model
{
    public class Teacher : User
    {
        public Class Class { get; set; } = new Class();
    }
}
