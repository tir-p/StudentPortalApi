using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
    /// <summary>
    /// Controller for managing Instructor resources.
    /// Follows RESTful conventions with proper HTTP verbs and status codes.
    /// Uses Service layer for business logic (Controller -> Service -> Repository pattern).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        /// <summary>
        /// Gets all instructors.
        /// </summary>
        /// <returns>List of all instructors</returns>
        /// <response code="200">Returns the list of instructors</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InstructorDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InstructorDTO>>> GetAll()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        /// <summary>
        /// Gets an instructor by ID.
        /// </summary>
        /// <param name="id">Instructor ID</param>
        /// <returns>Instructor details</returns>
        /// <response code="200">Returns the instructor</response>
        /// <response code="404">Instructor not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(InstructorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InstructorDTO>> GetById([FromRoute] int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
                return NotFound(new { message = $"Instructor with ID {id} not found." });

            return Ok(instructor);
        }

        /// <summary>
        /// Creates a new instructor.
        /// </summary>
        /// <param name="instructorDto">Instructor data</param>
        /// <returns>Created instructor</returns>
        /// <response code="201">Instructor created successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(InstructorDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InstructorDTO>> Create([FromBody] InstructorDTO instructorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _instructorService.CreateInstructorAsync(instructorDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing instructor.
        /// </summary>
        /// <param name="id">Instructor ID</param>
        /// <param name="instructorDto">Updated instructor data</param>
        /// <returns>Updated instructor</returns>
        /// <response code="200">Instructor updated successfully</response>
        /// <response code="400">Invalid input data</response>
        /// <response code="404">Instructor not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(InstructorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InstructorDTO>> Update([FromRoute] int id, [FromBody] InstructorDTO instructorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _instructorService.UpdateInstructorAsync(id, instructorDto);
            if (updated == null)
                return NotFound(new { message = $"Instructor with ID {id} not found." });

            return Ok(updated);
        }

        /// <summary>
        /// Deletes an instructor.
        /// </summary>
        /// <param name="id">Instructor ID</param>
        /// <returns>No content</returns>
        /// <response code="204">Instructor deleted successfully</response>
        /// <response code="404">Instructor not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _instructorService.DeleteInstructorAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Instructor with ID {id} not found." });

            return NoContent();
        }
    }
}

