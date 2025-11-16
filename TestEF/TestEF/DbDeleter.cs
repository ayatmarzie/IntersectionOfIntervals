using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.ClassLibrary1;
using TestEF;

namespace DAL
{
    public class DbDeleter
    {
        public static void DeleteBySelect(UniversityDbContext context)
        {
            var items = context.Students.Where(x => x.name == "Yan Li").ToList();

            context.Students.RemoveRange(items);
            context.SaveChanges();
        }
        

    


    }
}
