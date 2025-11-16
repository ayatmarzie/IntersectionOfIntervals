using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace TestEF
{
    

    namespace ClassLibrary1
    {
        public class UniversityDbContext : DbContext
        {
            public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
            {

            }
            public DbSet<Enrollment> Enrollments { get; set; }
            public DbSet<Teacher> Teacher { get; set; }
            public DbSet<Semester> Semester { get; set; }

            public DbSet<Course> Courses { get; set; }
            public DbSet<Student> Students { get; set; }
            protected override void OnModelCreating(ModelBuilder Builder)
            {
                Builder.Entity<Course>().ToTable("Course");
                Builder.Entity<Enrollment>().ToTable("Enrollment");
                Builder.Entity<Student>().ToTable("Student");
            }
            }
    }
}
