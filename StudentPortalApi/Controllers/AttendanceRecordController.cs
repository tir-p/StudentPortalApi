using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AttendanceRecordDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceRecordDTO>>> GetAll()
        {
            var records = await _attendanceRecordService.GetAllAttendanceRecordsAsync();
            return Ok(records);
        }

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

        [HttpGet("attendance/{attendanceId:int}")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceRecordDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AttendanceRecordDTO>>> GetByAttendanceId([FromRoute] int attendanceId)
        {
            var records = await _attendanceRecordService.GetAttendanceRecordsByAttendanceIdAsync(attendanceId);
            return Ok(records);
        }

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

