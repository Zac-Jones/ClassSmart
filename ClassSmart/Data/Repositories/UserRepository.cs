using ClassSmart.Model;

namespace ClassSmart.Data.Repositories
{
    /// <summary>
    /// Repository class for managing User entities.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a teacher by their email and password.
        /// </summary>
        /// <param name="email">The email of the teacher.</param>
        /// <param name="password">The password of the teacher.</param>
        /// <returns>The teacher entity matching the specified email and password.</returns>
        public Teacher GetTeacherByCredentials(string email, string password)
        {
            return _context.Teachers
                .FirstOrDefault(t => t.Email == email && t.Password == password);
        }

        /// <summary>
        /// Retrieves a student by their email and password.
        /// </summary>
        /// <param name="email">The email of the student.</param>
        /// <param name="password">The password of the student.</param>
        /// <returns>The student entity matching the specified email and password.</returns>
        public Student GetStudentByCredentials(string email, string password)
        {
            return _context.Students
                .FirstOrDefault(s => s.Email == email && s.Password == password);
        }

        /// <summary>
        /// Retrieves a teacher by their email.
        /// </summary>
        /// <param name="email">The email of the teacher.</param>
        /// <returns>The teacher entity matching the specified email.</returns>
        public Teacher GetTeacherByEmail(string email)
        {
            return _context.Teachers.FirstOrDefault(t => t.Email == email);
        }

        /// <summary>
        /// Retrieves a student by their email.
        /// </summary>
        /// <param name="email">The email of the student.</param>
        /// <returns>The student entity matching the specified email.</returns>
        public Student GetStudentByEmail(string email)
        {
            return _context.Students.FirstOrDefault(s => s.Email == email);
        }

        /// <summary>
        /// Updates an existing teacher in the database.
        /// </summary>
        /// <param name="teacher">The teacher entity to be updated.</param>
        public void UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }

        /// <summary>
        /// Adds a new teacher to the database.
        /// </summary>
        /// <param name="teacher">The teacher entity to be added.</param>
        public void AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        /// <summary>
        /// Adds a new student to the database.
        /// </summary>
        /// <param name="student">The student entity to be added.</param>
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retrieves a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>The student entity matching the specified ID.</returns>
        public Student GetStudentFromId(long id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }
    }
}
