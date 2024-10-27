using ClassSmart.Model;
using ClassSmart.Models;

namespace ClassSmart.Data.Repositories
{
    public interface IClassRepository
    {
        Class GetClassByTeacherId(int teacherId);
        void AddClass(Class newClass);
        List<Class> GetClassesByStudentId(int studentId);
        List<Student> GetStudentsByClassId(int classId);

        List<Quiz> GetQuizzesByClassId(int classId);
    }
}
