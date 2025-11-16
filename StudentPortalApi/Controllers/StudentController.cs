using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StudentPortalApi.Controllers
{
    /// <summary>
    /// Controller for managing Student resources.
    /// Follows RESTful conventions with proper HTTP verbs and status codes.
    /// Uses Service layer for business logic (Controller -> Service -> Repository pattern).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>List of all students</returns>
        /// <response code="200">Returns the list of students</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        /// <summary>
        /// Gets a student by ID.
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <returns>Student details</returns>
        /// <response code="200">Returns the student</response>
        /// <response code="404">Student not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> GetById([FromRoute] int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound(new { message = $"Student with ID {id} not found." });

            return Ok(student);
        }

        /// <summary>
        /// Creates a new student.
        /// </summary>
        /// <param name="studentDto">Student data</param>
        /// <returns>Created student</returns>
        /// <response code="201">Student created successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StudentDTO>> Create([FromBody] StudentDTO studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _studentService.CreateStudentAsync(studentDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <param name="studentDto">Updated student data</param>
        /// <returns>Updated student</returns>
        /// <response code="200">Student updated successfully</response>
        /// <response code="400">Invalid input data</response>
        /// <response code="404">Student not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> Update([FromRoute] int id, [FromBody] StudentDTO studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _studentService.UpdateStudentAsync(id, studentDto);
            if (updated == null)
                return NotFound(new { message = $"Student with ID {id} not found." });

            return Ok(updated);
        }

        /// <summary>
        /// Deletes a student.
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <returns>No content</returns>
        /// <response code="204">Student deleted successfully</response>
        /// <response code="404">Student not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _studentService.DeleteStudentAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Student with ID {id} not found." });

            return NoContent();
        }
    }
}
