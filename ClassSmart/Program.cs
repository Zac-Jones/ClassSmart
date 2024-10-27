using ClassSmart.Data;
using ClassSmart.Data.Repositories;
using ClassSmart.Forms;
using ClassSmart.Services;
using ClassSmart.Utilities;

namespace ClassSmart
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (var context = new ApplicationDBContext())
            {
                context.Database.EnsureCreated();

                var userRepository = new UserRepository(context);
                var classRepository = new ClassRepository(context);
                var quizRepository = new QuizRepository(context);
                var userService = new UserService(userRepository, classRepository);
                var quizService = new QuizService(classRepository, quizRepository, userRepository);

                PopulateTables.Init();
            }

            Application.Run(new LoginForm());   
        }
    }
}