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
        [Route("Selection")]
        public IEnumerable<string> GetSelectedStudents()
        {
            return service.GetselectedStudents();
        }
        [HttpGet]
        [Route("Selectionmany")]
        public IEnumerable<string> GetSelectedStudentNames()
        {
            return service.GetselectedStudents();
        }
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var success = service.DeleteStudent(id);

            if (!success)
                return NotFound($"Student with ID {id} not found.");

            return Ok($"Student with ID {id} deleted successfully.");
        }


        [HttpGet]
        [Route("Students")]
        public IEnumerable<Student> GetStudents()
        {
            return service.GetStudents();
        }

        [HttpPut]
        [Route("UpdateStudent/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = service.GetStudentById(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found.");

            // Update properties (example: name)
            student.name = updatedStudent.name;

            service.UpdateStudent(student);

            return Ok(student);
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
