using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
    /// <summary>
    /// Exposes endpoints for working with attendance summaries per student/course.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        /// <summary>
        /// Returns every attendance summary.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AttendanceDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetAll()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        /// <summary>
        /// Retrieves a single attendance summary by ID.
        /// </summary>
        /// <param name="id">Attendance identifier.</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AttendanceDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AttendanceDTO>> GetById([FromRoute] int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
                return NotFound(new { message = $"Attendance with ID {id} not found." });
            return Ok(attendance);
        }

        /// <summary>
        /// Gets attendance summaries for the given student.
        /// </summary>
        /// <param name="studentId">Student identifier.</param>
        [HttpGet("student/{studentId:int}")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetByStudentId([FromRoute] int studentId)
        {
            var attendances = await _attendanceService.GetAttendancesByStudentIdAsync(studentId);
            return Ok(attendances);
        }

        /// <summary>
        /// Gets attendance summaries for the given course.
        /// </summary>
        /// <param name="courseId">Course identifier.</param>
        [HttpGet("course/{courseId:int}")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetByCourseId([FromRoute] int courseId)
        {
            var attendances = await _attendanceService.GetAttendancesByCourseIdAsync(courseId);
            return Ok(attendances);
        }

        /// <summary>
        /// Creates a new attendance summary.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(AttendanceDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AttendanceDTO>> Create([FromBody] AttendanceDTO attendanceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _attendanceService.CreateAttendanceAsync(attendanceDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing attendance summary.
        /// </summary>
        /// <param name="id">Attendance identifier.</param>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(AttendanceDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AttendanceDTO>> Update([FromRoute] int id, [FromBody] AttendanceDTO attendanceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _attendanceService.UpdateAttendanceAsync(id, attendanceDto);
            if (updated == null)
                return NotFound(new { message = $"Attendance with ID {id} not found." });
            return Ok(updated);
        }

        /// <summary>
        /// Deletes an attendance summary.
        /// </summary>
        /// <param name="id">Attendance identifier.</param>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _attendanceService.DeleteAttendanceAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Attendance with ID {id} not found." });
            return NoContent();
        }
    }
}

