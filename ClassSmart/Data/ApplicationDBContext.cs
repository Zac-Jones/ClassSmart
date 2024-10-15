using Microsoft.EntityFrameworkCore;
using ClassSmart.Models;
using ClassSmart.Model;

namespace ClassSmart.Data
{
    internal class ApplicationDBContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=class_smart;User Id=root;Password=ASDr00tp@55;Port=3306;";
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
        }
    }
}
