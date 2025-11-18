using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEF
{
    namespace ClassLibrary1
    {
        public class Student
        {
            public List<Enrollment> Enrollments { get; set; }
            public int id { get; set; }
            public float average { get; set; }
            public string name { get; set; }
        }
        public class aqt
        {
            [Key]
            public int id5 { get; set; }

            [ForeignKey(nameof(bqt1))]
            public int? bqtID1 { get; set; }
            public bqt bqt1 { get; set; }
            [ForeignKey(nameof(bqt2))]
            public int? bqtID2 { get; set; }
            public bqt bqt2 { get; set; }
            public List<cqt> cqt { get; set; }
            [InverseProperty(nameof(r.aqt1))]
            public List<r> history { get; set; }
            [ForeignKey(nameof(last))]
            public int? lastID { get; set; }
            public r? last { get; set; }

        }
        public class r
        {

            public int id { get; set; }
            [ForeignKey(nameof(aqt1))]
            public int aqtID { get; set; }
            public aqt aqt1 { get; set; }
            [InverseProperty(nameof(aqt.last))]
            public List<aqt> aqt2 { get; set; }
        }
        public class cqt
        {
            public int id { get; set; }

            public List<aqt> aqt { get; set; }

        }
        public class bqt
        {
            [InverseProperty(nameof(aqt.bqt1))]
            public List<aqt> aqt1 { get; set; }
            [InverseProperty(nameof(aqt.bqt2))]
            public List<aqt> aqt2 { get; set; }
            public int id { get; set; }

        }
        
        public class dqt
        {
            public int id { get; set; }

        }
    }
}
