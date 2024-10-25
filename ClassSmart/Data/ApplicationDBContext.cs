using Microsoft.EntityFrameworkCore;
using ClassSmart.Models;
using ClassSmart.Model;
using DotNetEnv;

namespace ClassSmart.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Env.Load();

            string connectionString = $"Server={Env.GetString("DB_SERVER")};" +
                                      $"Database={Env.GetString("DB_DATABASE")};" +
                                      $"User Id={Env.GetString("DB_USER")};" +
                                      $"Password={Env.GetString("DB_PASSWORD")};" +
                                      $"Port={Env.GetString("DB_PORT")};";

            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithOne(t => t.Class)
                .HasForeignKey<Class>(c => c.TeacherId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Classes)
                .WithMany(c => c.Students);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Quizzes)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
