using ClassSmart.Model;
using ClassSmart.Models;

namespace ClassSmart.Services
{
    public interface IUserService
    {
        Teacher LoginTeacher(string email, string password);
        Student LoginStudent(string email, string password);
        Teacher InsertTeacher(string name, string email, string password);
        Student InsertStudent(string name, string email, string password);
        void AssignClassToTeacherAndStudent(Teacher teacher, Student student);
        List<Class> GetClassesForStudent(Student student);
        List<Student> GetStudentsForClass(Class _class);
        List<Quiz> GetQuizzesForClass(Class _class);
        Student GetStudentFromId(long id);
    }
}
