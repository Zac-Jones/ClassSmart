using ClassSmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public interface IUserRepository
    {
        Teacher GetTeacherByCredentials(string email, string password);
        Student GetStudentByCredentials(string email, string password);
        Teacher GetTeacherByEmail(string email);
        Student GetStudentByEmail(string email);

        Student GetStudentFromId(long id);
        void UpdateTeacher(Teacher teacher);
        void AddTeacher(Teacher teacher);
        void AddStudent(Student student);
    }
}
