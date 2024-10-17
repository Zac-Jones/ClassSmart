using ClassSmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Teacher GetTeacherByCredentials(string email, string password)
        {
            return _context.Teachers
                .FirstOrDefault(t => t.Email == email && t.Password == password);
        }

        public Student GetStudentByCredentials(string email, string password)
        {
            return _context.Students
                .FirstOrDefault(s => s.Email == email && s.Password == password);
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return _context.Teachers.FirstOrDefault(t => t.Email == email);
        }

        public Student GetStudentByEmail(string email)
        {
            return _context.Students.FirstOrDefault(s => s.Email == email);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
        }

        public void AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }
    }
}
