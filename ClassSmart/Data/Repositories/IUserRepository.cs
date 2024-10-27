using ClassSmart.Model;

namespace ClassSmart.Data.Repositories
{
    public interface IUserRepository
    {
        Teacher GetTeacherByCredentials(string email, string password);
        Student GetStudentByCredentials(string email, string password);
        Teacher GetTeacherByEmail(string email);
        Student GetStudentByEmail(string email);
        void UpdateTeacher(Teacher teacher);
        void AddTeacher(Teacher teacher);
        void AddStudent(Student student);
        Student GetStudentFromId(long id);
    }
}
