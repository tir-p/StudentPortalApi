using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
    /// <summary>
    /// Controller for managing Grade resources.
    /// Follows RESTful conventions with proper HTTP verbs and status codes.
    /// Uses Service layer for business logic (Controller -> Service -> Repository pattern).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        /// <summary>
        /// Gets all grades.
        /// </summary>
        /// <returns>List of all grades</returns>
        /// <response code="200">Returns the list of grades</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GradeDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GradeDTO>>> GetAll()
        {
            var grades = await _gradeService.GetAllGradesAsync();
            return Ok(grades);
        }

        /// <summary>
        /// Gets a grade by ID.
        /// </summary>
        /// <param name="id">Grade ID</param>
        /// <returns>Grade details</returns>
        /// <response code="200">Returns the grade</response>
        /// <response code="404">Grade not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GradeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GradeDTO>> GetById([FromRoute] int id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null)
                return NotFound(new { message = $"Grade with ID {id} not found." });

            return Ok(grade);
        }

        /// <summary>
        /// Gets grades by Student ID.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        /// <returns>List of grades for the student</returns>
        /// <response code="200">Returns the list of grades</response>
        [HttpGet("student/{studentId:int}")]
        [ProducesResponseType(typeof(IEnumerable<GradeDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GradeDTO>>> GetByStudentId([FromRoute] int studentId)
        {
            var grades = await _gradeService.GetGradesByStudentIdAsync(studentId);
            return Ok(grades);
        }

        /// <summary>
        /// Gets grades by Course ID.
        /// </summary>
        /// <param name="courseId">Course ID</param>
        /// <returns>List of grades for the course</returns>
        /// <response code="200">Returns the list of grades</response>
        [HttpGet("course/{courseId:int}")]
        [ProducesResponseType(typeof(IEnumerable<GradeDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GradeDTO>>> GetByCourseId([FromRoute] int courseId)
        {
            var grades = await _gradeService.GetGradesByCourseIdAsync(courseId);
            return Ok(grades);
        }

        /// <summary>
        /// Creates a new grade.
        /// </summary>
        /// <param name="gradeDto">Grade data</param>
        /// <returns>Created grade</returns>
        /// <response code="201">Grade created successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(GradeDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GradeDTO>> Create([FromBody] GradeDTO gradeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _gradeService.CreateGradeAsync(gradeDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing grade.
        /// </summary>
        /// <param name="id">Grade ID</param>
        /// <param name="gradeDto">Updated grade data</param>
        /// <returns>Updated grade</returns>
        /// <response code="200">Grade updated successfully</response>
        /// <response code="400">Invalid input data</response>
        /// <response code="404">Grade not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(GradeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GradeDTO>> Update([FromRoute] int id, [FromBody] GradeDTO gradeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _gradeService.UpdateGradeAsync(id, gradeDto);
            if (updated == null)
                return NotFound(new { message = $"Grade with ID {id} not found." });

            return Ok(updated);
        }

        /// <summary>
        /// Deletes a grade.
        /// </summary>
        /// <param name="id">Grade ID</param>
        /// <returns>No content</returns>
        /// <response code="204">Grade deleted successfully</response>
        /// <response code="404">Grade not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _gradeService.DeleteGradeAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Grade with ID {id} not found." });

            return NoContent();
        }
    }
}

