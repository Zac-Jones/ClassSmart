using ClassSmart.Data.Repositories;
using ClassSmart.Model;
using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassRepository _classRepository;

        public UserService(IUserRepository userRepository, IClassRepository classRepository)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;
        }

        public Teacher LoginTeacher(string email, string password)
        {
            return _userRepository.GetTeacherByCredentials(email, password);
        }

        public Student LoginStudent(string email, string password)
        {
            return _userRepository.GetStudentByCredentials(email, password);
        }

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

                _classRepository.AddClass(newClass);
            }
        }

        public List<Class> GetClassesForStudent(Student student)
        {
            return _classRepository.GetClassesByStudentId(student.Id);
        }

        public List<Student> GetStudentsForClass(Class _class)
        {
            return _classRepository.GetStudentsByClassId(_class.Id);
        }
    }
}