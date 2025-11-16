using System.ComponentModel.DataAnnotations.Schema;

namespace TestEF
{
    namespace ClassLibrary1
    {
        public class Course
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int id { get; set; }
            public int unit { get; set; }


            public string name { get; set; }
        }
    }
}
