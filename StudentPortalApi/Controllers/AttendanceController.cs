using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AttendanceDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetAll()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

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

        [HttpGet("student/{studentId:int}")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetByStudentId([FromRoute] int studentId)
        {
            var attendances = await _attendanceService.GetAttendancesByStudentIdAsync(studentId);
            return Ok(attendances);
        }

        [HttpGet("course/{courseId:int}")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetByCourseId([FromRoute] int courseId)
        {
            var attendances = await _attendanceService.GetAttendancesByCourseIdAsync(courseId);
            return Ok(attendances);
        }

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

