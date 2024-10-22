using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Forms.Main;
using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;
using System;
using System.Linq;

namespace ClassSmart.Utilities
{
    public class PopulateTables
    {
        public static void Init()
        {
            var dbContext = new ApplicationDBContext();
            var userRepository = new UserRepository(dbContext);
            var classRepository = new ClassRepository(dbContext);
            var userService = new UserService(userRepository, classRepository);

            var teacher = userService.InsertTeacher("Test Teacher", "test@teacher.com", "password");
            var student = userService.InsertStudent("John Doe", "john@doe.com", "password");

            userService.AssignClassToTeacherAndStudent(teacher, student);

            dbContext.SaveChanges();
        }
    }
}
