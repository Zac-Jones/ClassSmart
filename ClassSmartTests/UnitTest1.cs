using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;
using ClassSmart.Utilities;
using Moq;

namespace ClassSmartTests
{
    /// <summary>
    /// Unit tests for the ClassSmart application.
    /// </summary>
    public class Tests
    {
        private Mock<ApplicationDBContext> _mockDbContext;
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IClassRepository> _mockClassRepository;
        private Mock<IQuizRepository> _mockQuizRepository;
        private Mock<IUserService> _mockUserService;
        private Mock<IQuizService> _mockQuizService;

        /// <summary>
        /// Sets up the mock objects before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockDbContext = new Mock<ApplicationDBContext>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockClassRepository = new Mock<IClassRepository>();
            _mockQuizRepository = new Mock<IQuizRepository>();
            _mockUserService = new Mock<IUserService>();
            _mockQuizService = new Mock<IQuizService>();
        }

        /// <summary>
        /// Tests that the Init method inserts a teacher and a student.
        /// </summary>
        [Test]
        public void Init_ShouldInsertTeacherAndStudent()
        {
            // Arrange
            var teacher = new Teacher { Name = "Test Teacher", Email = "test@teacher.com" };
            var student = new Student { Name = "John Doe", Email = "john@doe.com" };

            _mockUserService.Setup(us => us.InsertTeacher(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(teacher);
            _mockUserService.Setup(us => us.InsertStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(student);
            _mockQuizService.Setup(qs => qs.GetQuizzesByTeacher(It.IsAny<Teacher>())).Returns(new List<Quiz>());

            // Act
            PopulateTables.InitTests(_mockUserService.Object, _mockQuizService.Object);

            // Assert
            _mockUserService.Verify(us => us.InsertTeacher("Test Teacher", "test@teacher.com", "password"), Times.Once);
            _mockUserService.Verify(us => us.InsertStudent("John Doe", "john@doe.com", "password"), Times.Once);
        }

        /// <summary>
        /// Tests that the Init method creates a quiz for the teacher.
        /// </summary>
        [Test]
        public void Init_ShouldCreateQuizForTeacher()
        {
            // Arrange
            var teacher = new Teacher { Name = "Test Teacher", Email = "test@teacher.com" };
            var student = new Student { Name = "John Doe", Email = "john@doe.com" };

            _mockUserService.Setup(us => us.InsertTeacher(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(teacher);
            _mockUserService.Setup(us => us.InsertStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(student);
            _mockQuizService.Setup(qs => qs.GetQuizzesByTeacher(It.IsAny<Teacher>())).Returns(new List<Quiz>());

            // Act
            PopulateTables.InitTests(_mockUserService.Object, _mockQuizService.Object);

            // Assert
            _mockQuizService.Verify(qs => qs.CreateQuizForTeacher(It.IsAny<Teacher>(), It.IsAny<Quiz>()), Times.Once);
        }

        /// <summary>
        /// Tests that the Init method assigns a class to the teacher and student.
        /// </summary>
        [Test]
        public void Init_ShouldAssignClassToTeacherAndStudent()
        {
            // Arrange
            var teacher = new Teacher { Name = "Test Teacher", Email = "test@teacher.com" };
            var student = new Student { Name = "John Doe", Email = "john@doe.com" };

            _mockUserService.Setup(us => us.InsertTeacher(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(teacher);
            _mockUserService.Setup(us => us.InsertStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(student);
            _mockQuizService.Setup(qs => qs.GetQuizzesByTeacher(It.IsAny<Teacher>())).Returns(new List<Quiz>());

            // Act
            PopulateTables.InitTests(_mockUserService.Object, _mockQuizService.Object);

            // Assert
            _mockUserService.Verify(us => us.AssignClassToTeacherAndStudent(teacher, student), Times.Once);
        }
    }
}
