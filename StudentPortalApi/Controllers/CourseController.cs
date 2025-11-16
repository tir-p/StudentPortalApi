using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
    /// <summary>
    /// Controller for managing Course resources.
    /// Follows RESTful conventions with proper HTTP verbs and status codes.
    /// Uses Service layer for business logic (Controller -> Service -> Repository pattern).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns>List of all courses</returns>
        /// <response code="200">Returns the list of courses</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAll()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        /// <summary>
        /// Gets a course by ID.
        /// </summary>
        /// <param name="id">Course ID</param>
        /// <returns>Course details</returns>
        /// <response code="200">Returns the course</response>
        /// <response code="404">Course not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CourseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseDTO>> GetById([FromRoute] int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound(new { message = $"Course with ID {id} not found." });

            return Ok(course);
        }

        /// <summary>
        /// Gets courses by Instructor ID.
        /// </summary>
        /// <param name="instructorId">Instructor ID</param>
        /// <returns>List of courses for the instructor</returns>
        /// <response code="200">Returns the list of courses</response>
        [HttpGet("instructor/{instructorId:int}")]
        [ProducesResponseType(typeof(IEnumerable<CourseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetByInstructorId([FromRoute] int instructorId)
        {
            var courses = await _courseService.GetCoursesByInstructorIdAsync(instructorId);
            return Ok(courses);
        }

        /// <summary>
        /// Creates a new course.
        /// </summary>
        /// <param name="courseDto">Course data</param>
        /// <returns>Created course</returns>
        /// <response code="201">Course created successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(CourseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CourseDTO>> Create([FromBody] CourseDTO courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _courseService.CreateCourseAsync(courseDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing course.
        /// </summary>
        /// <param name="id">Course ID</param>
        /// <param name="courseDto">Updated course data</param>
        /// <returns>Updated course</returns>
        /// <response code="200">Course updated successfully</response>
        /// <response code="400">Invalid input data</response>
        /// <response code="404">Course not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(CourseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseDTO>> Update([FromRoute] int id, [FromBody] CourseDTO courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _courseService.UpdateCourseAsync(id, courseDto);
            if (updated == null)
                return NotFound(new { message = $"Course with ID {id} not found." });

            return Ok(updated);
        }

        /// <summary>
        /// Deletes a course.
        /// </summary>
        /// <param name="id">Course ID</param>
        /// <returns>No content</returns>
        /// <response code="204">Course deleted successfully</response>
        /// <response code="404">Course not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _courseService.DeleteCourseAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Course with ID {id} not found." });

            return NoContent();
        }
    }
}

