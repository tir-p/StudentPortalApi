using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
    /// <summary>
    /// API endpoints for managing the course timetable.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CourseScheduleController : ControllerBase
    {
        private readonly ICourseScheduleService _courseScheduleService;

        public CourseScheduleController(ICourseScheduleService courseScheduleService)
        {
            _courseScheduleService = courseScheduleService;
        }

        /// <summary>
        /// Returns every schedule entry.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseScheduleDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CourseScheduleDTO>>> GetAll()
        {
            var schedules = await _courseScheduleService.GetAllCourseSchedulesAsync();
            return Ok(schedules);
        }

        /// <summary>
        /// Retrieves a schedule record by ID.
        /// </summary>
        /// <param name="id">Schedule identifier.</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CourseScheduleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseScheduleDTO>> GetById([FromRoute] int id)
        {
            var schedule = await _courseScheduleService.GetCourseScheduleByIdAsync(id);
            if (schedule == null)
                return NotFound(new { message = $"Course schedule with ID {id} not found." });
            return Ok(schedule);
        }

        /// <summary>
        /// Lists schedule entries attached to a given course.
        /// </summary>
        /// <param name="courseId">Course identifier.</param>
        [HttpGet("course/{courseId:int}")]
        [ProducesResponseType(typeof(IEnumerable<CourseScheduleDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CourseScheduleDTO>>> GetByCourseId([FromRoute] int courseId)
        {
            var schedules = await _courseScheduleService.GetCourseSchedulesByCourseIdAsync(courseId);
            return Ok(schedules);
        }

        /// <summary>
        /// Creates a new course schedule entry.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(CourseScheduleDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CourseScheduleDTO>> Create([FromBody] CourseScheduleDTO courseScheduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _courseScheduleService.CreateCourseScheduleAsync(courseScheduleDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates a schedule entry.
        /// </summary>
        /// <param name="id">Schedule identifier.</param>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(CourseScheduleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseScheduleDTO>> Update([FromRoute] int id, [FromBody] CourseScheduleDTO courseScheduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _courseScheduleService.UpdateCourseScheduleAsync(id, courseScheduleDto);
            if (updated == null)
                return NotFound(new { message = $"Course schedule with ID {id} not found." });
            return Ok(updated);
        }

        /// <summary>
        /// Deletes a schedule entry.
        /// </summary>
        /// <param name="id">Schedule identifier.</param>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _courseScheduleService.DeleteCourseScheduleAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Course schedule with ID {id} not found." });
            return NoContent();
        }
    }
}

