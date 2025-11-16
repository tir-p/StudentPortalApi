using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AssignmentDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AssignmentDTO>>> GetAll()
        {
            var assignments = await _assignmentService.GetAllAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AssignmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AssignmentDTO>> GetById([FromRoute] int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
                return NotFound(new { message = $"Assignment with ID {id} not found." });
            return Ok(assignment);
        }

        [HttpGet("grade/{gradeId:int}")]
        [ProducesResponseType(typeof(IEnumerable<AssignmentDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AssignmentDTO>>> GetByGradeId([FromRoute] int gradeId)
        {
            var assignments = await _assignmentService.GetAssignmentsByGradeIdAsync(gradeId);
            return Ok(assignments);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AssignmentDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AssignmentDTO>> Create([FromBody] AssignmentDTO assignmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _assignmentService.CreateAssignmentAsync(assignmentDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(AssignmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AssignmentDTO>> Update([FromRoute] int id, [FromBody] AssignmentDTO assignmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _assignmentService.UpdateAssignmentAsync(id, assignmentDto);
            if (updated == null)
                return NotFound(new { message = $"Assignment with ID {id} not found." });
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _assignmentService.DeleteAssignmentAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Assignment with ID {id} not found." });
            return NoContent();
        }
    }
}

