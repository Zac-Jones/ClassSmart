using ClassSmart.Data;
using ClassSmart.Model;
using System;
using System.Linq;

namespace ClassSmart.Utilities
{
    public class PopulateTables
    {
        public static void InsertUsers()
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

                var existingStudent = context.Students.FirstOrDefault(t => t.Email == "john@doe.com");

                if (existingStudent == null)
                {
                    var newStudent = new Student
                    {
                        Name = "John Doe",
                        Email = "john@doe.com",
                        Password = "password"
                    };

                    context.Students.Add(newStudent);
                    context.SaveChanges();
                }
            }
        }
    }
}
