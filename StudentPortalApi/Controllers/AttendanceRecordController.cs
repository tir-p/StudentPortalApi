using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
    /// <summary>
    /// Provides CRUD endpoints for fine-grained attendance entries linked to a student's course.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AttendanceRecordController : ControllerBase
    {
        private readonly IAttendanceRecordService _attendanceRecordService;

        public AttendanceRecordController(IAttendanceRecordService attendanceRecordService)
        {
            _attendanceRecordService = attendanceRecordService;
        }

        /// <summary>
        /// Returns all attendance records in the system.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AttendanceRecordDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceRecordDTO>>> GetAll()
        {
            var records = await _attendanceRecordService.GetAllAttendanceRecordsAsync();
            return Ok(records);
        }

        /// <summary>
        /// Retrieves a single attendance record by identifier.
        /// </summary>
        /// <param name="id">Attendance record ID.</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AttendanceRecordDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AttendanceRecordDTO>> GetById([FromRoute] int id)
        {
            var record = await _attendanceRecordService.GetAttendanceRecordByIdAsync(id);
            if (record == null)
                return NotFound(new { message = $"Attendance record with ID {id} not found." });
            return Ok(record);
        }

        /// <summary>
        /// Fetches all attendance records tied to a parent attendance summary.
        /// </summary>
        /// <param name="attendanceId">Attendance summary ID.</param>
        [HttpGet("attendance/{attendanceId:int}")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceRecordDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceRecordDTO>>> GetByAttendanceId([FromRoute] int attendanceId)
        {
            var records = await _attendanceRecordService.GetAttendanceRecordsByAttendanceIdAsync(attendanceId);
            return Ok(records);
        }

        /// <summary>
        /// Creates a new attendance record entry.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(AttendanceRecordDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AttendanceRecordDTO>> Create([FromBody] AttendanceRecordDTO attendanceRecordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _attendanceRecordService.CreateAttendanceRecordAsync(attendanceRecordDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing attendance record.
        /// </summary>
        /// <param name="id">Attendance record ID.</param>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(AttendanceRecordDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AttendanceRecordDTO>> Update([FromRoute] int id, [FromBody] AttendanceRecordDTO attendanceRecordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _attendanceRecordService.UpdateAttendanceRecordAsync(id, attendanceRecordDto);
            if (updated == null)
                return NotFound(new { message = $"Attendance record with ID {id} not found." });
            return Ok(updated);
        }

        /// <summary>
        /// Deletes an attendance record.
        /// </summary>
        /// <param name="id">Attendance record ID.</param>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _attendanceRecordService.DeleteAttendanceRecordAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Attendance record with ID {id} not found." });
            return NoContent();
        }
    }
}

