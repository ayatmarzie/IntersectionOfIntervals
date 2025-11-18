namespace TestEF
{
    namespace ClassLibrary1
    {
        public class Semester
        {
            public int id { get; set; }
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public string name { get; set; }
            public Semister_type type { get; set; }
        }
    }
}
