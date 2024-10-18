using ClassSmart.Data;
using ClassSmart.Forms;
using ClassSmart.Model;
using ClassSmart.Utilities;
using Microsoft.EntityFrameworkCore;

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
            //PopulateTables.InsertTeachers();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (var context = new ApplicationDBContext())
            {
                context.Database.EnsureCreated();
            }
            
            PopulateTables.Init();

            Application.Run(new LoginForm());   
        }
    }
}