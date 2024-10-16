using ClassSmart.Data;
using ClassSmart.Model;
using System;
using System.Linq;

namespace ClassSmart.Utilities
{
    public class PopulateTables
    {
        public static void InsertTeachers()
        {
            using (var context = new ApplicationDBContext())
            {
                var existingTeacher = context.Teachers.FirstOrDefault(t => t.Email == "test@teacher.com");

                if (existingTeacher == null)
                {
                    var newTeacher = new Teacher
                    {
                        Name = "Test Teacher",
                        Email = "test@teacher.com",
                        Password = "password"
                    };

                    context.Teachers.Add(newTeacher);
                    context.SaveChanges();
                }
            }
        }
    }
}
