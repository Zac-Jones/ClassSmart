using ClassSmart.Model;
using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDBContext _context;

        public ClassRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Class GetClassByTeacherId(int teacherId)
        {
            return _context.Classes.FirstOrDefault(c => c.TeacherId == teacherId);
        }

        public void AddClass(Class newClass)
        {
            _context.Classes.Add(newClass);
            _context.SaveChanges();
        }

        public List<Class> GetClassesByStudentId(int studentId)
        {
            return _context.Classes.Where(c => c.Students.Any(s => s.Id == studentId)).ToList();
        }

        public List<Student> GetStudentsByClassId(int classId)
        {
            return _context.Classes.Where(c => c.Id == classId).SelectMany(c => c.Students).ToList();
        }

        public List<Quiz> GetQuizzesByClassId(int classId)
        {
            return _context.Classes.Where(c => c.Id == classId).SelectMany(c => c.Quizzes).ToList();
        }
    }
}
