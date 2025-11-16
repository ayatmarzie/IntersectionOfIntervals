using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.ClassLibrary1;

namespace DAL
{
    public class Update
    {
        public static void UpdateRecord(UniversityDbContext context)
        {
            var student = context.Students.Find(5);

            if (student == null)
            {
                Console.WriteLine("Student with ID 5 not found.");
                return;
            }

            student.name = "Marzieh Ayat";
            context.SaveChanges();





        }
    }
}
