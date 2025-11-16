using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.ClassLibrary1;

namespace Core.Services
{
    public class UniversityService(UniversityDbContext db)
    {
        public void AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public IEnumerable<Student> GetStudents()
        {
            return  db.Students.ToArray();
            
        }
        public Student GetStudentById(int id)
        {
            return db.Students.Find(id);
        }

        public void UpdateStudent(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
        public bool DeleteStudent(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
                return false;

            db.Students.Remove(student);
            db.SaveChanges();
            return true;
        }
        public IEnumerable<string> GetselectedStudents()
        {
            return db.Enrollments.Where(s => s.CourseID== 1050).
            Select(s => s.Student.name)
    .Distinct()
             .ToList();
        }
        public IEnumerable<string> GetSelectedStudentNames(int courseId)
        {
            return db.Enrollments
                     .Where(e => e.CourseID == courseId)
                     .SelectMany(e => db.Students
                                        .Where(s => s.id == e.StudentID)
                                        .Select(s => s.name))
                     .Distinct()
                     .ToList();
        }



    }
}
