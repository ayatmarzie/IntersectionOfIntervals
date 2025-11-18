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
            //db.aqt4.Include(x => x.history).Include(y=>y.bqt1).Where();
            //db.Students.Where(x => x.Enrollments.Any(x => x.CourseID == 1050));
            db.Students.Add(student);
            db.SaveChanges();
        }

        public IEnumerable<Student> GetStudents()
        {
           var Query = db.Students.Select(x=>new { name=x.name,eCount=x.Enrollments.Count,ncourse=x.Enrollments.Select(y=>y.Course.name)}).AsQueryable();
            var q = Query.ToQueryString();
            var result = Query.ToArray();
            return new List<Student>();
            
        }
        public Student GetStudentById(int id)
        {
            return db.Students.Include(x=>x.Enrollments).ThenInclude(x=>x.Course).FirstOrDefault(x=>x.id==id);
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
