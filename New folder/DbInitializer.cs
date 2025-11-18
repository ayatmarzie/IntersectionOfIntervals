using System;
using System.Linq;
using TestEF;
using TestEF.ClassLibrary1;

namespace DAL
{
    public class DbInitializer
    {
        public static void Initialize(UniversityDbContext context)
        {
            context.Database.EnsureCreated();

            // If the DB already contains students → it has been seeded
            if (context.Students.Any())
                return;

            // ---------- STUDENTS ----------
            var students = new[]
            {
                new Student { name = "Carson Alexander", average = 0 },
                new Student { name = "Meredith Alonso",   average = 0 },
                new Student { name = "Arturo Anand",      average = 0 },
                new Student { name = "Gytis Barzdukas",   average = 0 },
                new Student { name = "Yan Li",            average = 0 },
                new Student { name = "Peggy Justice",     average = 0 },
                new Student { name = "Laura Norman",      average = 0 },
                new Student { name = "Nino Olivetto",     average = 0 }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            // ---------- COURSES ----------
            var courses = new[]
            {
                new Course { id = 1050, name = "Chemistry",       unit = 3 },
                new Course { id = 4022, name = "Microeconomics", unit = 3 },
                new Course { id = 4041, name = "Macroeconomics", unit = 3 },
                new Course { id = 1045, name = "Calculus",       unit = 4 },
                new Course { id = 3141, name = "Trigonometry",   unit = 4 },
                new Course { id = 2021, name = "Composition",    unit = 3 },
                new Course { id = 2042, name = "Literature",     unit = 4 }
            };

            context.Courses.AddRange(courses);   // DbSet is named "Courses"
            context.SaveChanges();

            // ---------- ENROLLMENTS ----------
            var enrollments = new[]
            {
                new Enrollment { StudentID = 1, CourseID = 1050, Grade = Grade.A },
                new Enrollment { StudentID = 1, CourseID = 4022, Grade = Grade.C },
                new Enrollment { StudentID = 1, CourseID = 4041, Grade = Grade.B },

                new Enrollment { StudentID = 2, CourseID = 1045, Grade = Grade.B },
                new Enrollment { StudentID = 2, CourseID = 3141, Grade = Grade.F },
                new Enrollment { StudentID = 2, CourseID = 2021, Grade = Grade.F },

                new Enrollment { StudentID = 3, CourseID = 1050 },
                new Enrollment { StudentID = 4, CourseID = 1050 },
                new Enrollment { StudentID = 4, CourseID = 4022, Grade = Grade.F },

                new Enrollment { StudentID = 5, CourseID = 4041, Grade = Grade.C },
                new Enrollment { StudentID = 6, CourseID = 1045 },
                new Enrollment { StudentID = 7, CourseID = 3141, Grade = Grade.A }
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}