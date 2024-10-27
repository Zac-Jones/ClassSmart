using ClassSmart.Data.Repositories;
using ClassSmart.Model;
using ClassSmart.Models;

namespace ClassSmart.Services
{
    /// <summary>
    /// Service class for managing users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassRepository _classRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="classRepository">The class repository.</param>
        public UserService(IUserRepository userRepository, IClassRepository classRepository)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;
        }

        /// <summary>
        /// Logs in a teacher using email and password.
        /// </summary>
        /// <param name="email">The teacher's email.</param>
        /// <param name="password">The teacher's password.</param>
        /// <returns>The logged-in teacher.</returns>
        public Teacher LoginTeacher(string email, string password)
        {
            return _userRepository.GetTeacherByCredentials(email, password);
        }

        /// <summary>
        /// Logs in a student using email and password.
        /// </summary>
        /// <param name="email">The student's email.</param>
        /// <param name="password">The student's password.</param>
        /// <returns>The logged-in student.</returns>
        public Student LoginStudent(string email, string password)
        {
            return _userRepository.GetStudentByCredentials(email, password);
        }

        /// <summary>
        /// Inserts a new teacher.
        /// </summary>
        /// <param name="name">The teacher's name.</param>
        /// <param name="email">The teacher's email.</param>
        /// <param name="password">The teacher's password.</param>
        /// <returns>The inserted teacher.</returns>
        public Teacher InsertTeacher(string name, string email, string password)
        {
            var existingTeacher = _userRepository.GetTeacherByEmail(email);

            if (existingTeacher == null)
            {
                var newTeacher = new Teacher
                {
                    Name = name,
                    Email = email,
                    Password = password
                };

                _userRepository.AddTeacher(newTeacher);
                return newTeacher;
            }

            return existingTeacher;
        }

        /// <summary>
        /// Inserts a new student.
        /// </summary>
        /// <param name="name">The student's name.</param>
        /// <param name="email">The student's email.</param>
        /// <param name="password">The student's password.</param>
        /// <returns>The inserted student.</returns>
        public Student InsertStudent(string name, string email, string password)
        {
            var existingStudent = _userRepository.GetStudentByEmail(email);

            if (existingStudent == null)
            {
                var newStudent = new Student
                {
                    Name = name,
                    Email = email,
                    Password = password
                };

                _userRepository.AddStudent(newStudent);
                return newStudent;
            }

            return existingStudent;
        }

        /// <summary>
        /// Assigns a class to a teacher and a student.
        /// </summary>
        /// <param name="teacher">The teacher.</param>
        /// <param name="student">The student.</param>
        public void AssignClassToTeacherAndStudent(Teacher teacher, Student student)
        {
            var existingClass = _classRepository.GetClassByTeacherId(teacher.Id);

            if (existingClass == null)
            {
                var newClass = new Class
                {
                    TeacherId = teacher.Id,
                    Teacher = teacher,
                    Students = new List<Student> { student }
                };

                if (!student.Classes.Contains(newClass))
                {
                    student.Classes.Add(newClass);
                }

                _classRepository.AddClass(newClass);
            }
            else
            {
                if (!existingClass.Students.Contains(student))
                {
                    existingClass.Students.Add(student);
                }

                if (!student.Classes.Contains(existingClass))
                {
                    student.Classes.Add(existingClass);
                }
            }
        }

        /// <summary>
        /// Gets the classes for a specific student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns>A list of classes associated with the specified student.</returns>
        public List<Class> GetClassesForStudent(Student student)
        {
            return _classRepository.GetClassesByStudentId(student.Id);
        }

        /// <summary>
        /// Gets the students for a specific class.
        /// </summary>
        /// <param name="_class">The class.</param>
        /// <returns>A list of students associated with the specified class.</returns>
        public List<Student> GetStudentsForClass(Class _class)
        {
            return _classRepository.GetStudentsByClassId(_class.Id);
        }

        /// <summary>
        /// Gets the quizzes for a specific class.
        /// </summary>
        /// <param name="_class">The class.</param>
        /// <returns>A list of quizzes associated with the specified class.</returns>
        public List<Quiz> GetQuizzesForClass(Class _class)
        {
            return _classRepository.GetQuizzesByClassId(_class.Id);
        }

        /// <summary>
        /// Gets a student by their identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <returns>The student with the specified identifier.</returns>
        public Student GetStudentFromId(long id)
        {
            return _userRepository.GetStudentFromId(id);
        }
    }
}
