using ClassSmart.Model;
using ClassSmart.Models;

namespace ClassSmart.Data.Repositories
{
    /// <summary>
    /// Repository class for managing Class entities.
    /// </summary>
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public ClassRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a class associated with a specific teacher ID.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher.</param>
        /// <returns>The class associated with the specified teacher ID.</returns>
        public Class GetClassByTeacherId(int teacherId)
        {
            return _context.Classes.FirstOrDefault(c => c.TeacherId == teacherId);
        }

        /// <summary>
        /// Adds a new class to the database.
        /// </summary>
        /// <param name="newClass">The class entity to be added.</param>
        public void AddClass(Class newClass)
        {
            _context.Classes.Add(newClass);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retrieves a list of classes associated with a specific student ID.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>A list of classes associated with the specified student ID.</returns>
        public List<Class> GetClassesByStudentId(int studentId)
        {
            return _context.Classes.Where(c => c.Students.Any(s => s.Id == studentId)).ToList();
        }

        /// <summary>
        /// Retrieves a list of students associated with a specific class ID.
        /// </summary>
        /// <param name="classId">The ID of the class.</param>
        /// <returns>A list of students associated with the specified class ID.</returns>
        public List<Student> GetStudentsByClassId(int classId)
        {
            return _context.Classes.Where(c => c.Id == classId).SelectMany(c => c.Students).ToList();
        }

        /// <summary>
        /// Retrieves a list of quizzes associated with a specific class ID.
        /// </summary>
        /// <param name="classId">The ID of the class.</param>
        /// <returns>A list of quizzes associated with the specified class ID.</returns>
        public List<Quiz> GetQuizzesByClassId(int classId)
        {
            return _context.Classes.Where(c => c.Id == classId).SelectMany(c => c.Quizzes).ToList();
        }
    }
}
