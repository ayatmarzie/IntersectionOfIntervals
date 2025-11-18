using Core.Services;
using Microsoft.AspNetCore.Mvc;
using TestEF.ClassLibrary1;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController(UniversityService service, ILogger<UniversityController> logger) : ControllerBase
    {



        [HttpGet]
        [Route("Students")]
        public IEnumerable<Student> GetStudents()
        {
            return service.GetStudents();
        }


        [HttpPost]
        [Route("AddStudent")]
        public bool AddStudent(Student student)
        {
            service.AddStudent(student);
            return true;
        }
    }
}
