using asp_student_crud_api.Models;
using asp_student_crud_api.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp_student_crud_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentRepository = studentsRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null) 
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddStudent([FromBody] StudentModel studentModel)
        {
            var id = await _studentRepository.AddStudentAsync(studentModel);

            return CreatedAtAction(
                nameof(GetStudentById),
                new { id = id, controller = "students" },
                id
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(
            [FromBody]StudentModel studentModel,
            [FromRoute]int id
        )
        {
            await _studentRepository.UpdateStudentAsync(id, studentModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStudentPatch(
            [FromBody] JsonPatchDocument studentModel,
            [FromRoute] int id
        )
        {
            await _studentRepository.UpdateStudentPatchAsync(id, studentModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
            return Ok();
        }
    }
}
