using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class student
    {
        public int id { get; set; }
        public float average { get; set; }
        public string name { get; set; }
    }
    public class Course
    {
        public int id { get; set; }
        public int unit {  get; set; }


        public string name { get; set; }
    }
    public class semister
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string name { get; set; }
        public semister_type type { get; set; }
    }
    public class Teacher
    {
        public int id { get; set; }
        public int Salary { get; set; }

        public string name { get; set; }
    }
    public enum semister_type { bahar=1,payeez=2, tabestan=3 }
    public class UniversityDbContext : DbContext
    {
        public
    }
}
