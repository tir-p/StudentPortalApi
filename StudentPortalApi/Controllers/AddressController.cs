using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Controllers
{
    /// <summary>
    /// Controller for managing Address resources.
    /// Follows RESTful conventions with proper HTTP verbs and status codes.
    /// Uses Service layer for business logic (Controller -> Service -> Repository pattern).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns>List of all addresses</returns>
        /// <response code="200">Returns the list of addresses</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AddressDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAll()
        {
            var addresses = await _addressService.GetAllAddressesAsync();
            return Ok(addresses);
        }

        /// <summary>
        /// Gets an address by ID.
        /// </summary>
        /// <param name="id">Address ID</param>
        /// <returns>Address details</returns>
        /// <response code="200">Returns the address</response>
        /// <response code="404">Address not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AddressDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDTO>> GetById([FromRoute] int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address == null)
                return NotFound(new { message = $"Address with ID {id} not found." });

            return Ok(address);
        }

        /// <summary>
        /// Gets an address by Student ID.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        /// <returns>Address details for the student</returns>
        /// <response code="200">Returns the address</response>
        /// <response code="404">Address not found for the student</response>
        [HttpGet("student/{studentId:int}")]
        [ProducesResponseType(typeof(AddressDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDTO>> GetByStudentId([FromRoute] int studentId)
        {
            var address = await _addressService.GetAddressByStudentIdAsync(studentId);
            if (address == null)
                return NotFound(new { message = $"Address for Student ID {studentId} not found." });

            return Ok(address);
        }

        /// <summary>
        /// Creates a new address.
        /// </summary>
        /// <param name="addressDto">Address data</param>
        /// <returns>Created address</returns>
        /// <response code="201">Address created successfully</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(AddressDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddressDTO>> Create([FromBody] AddressDTO addressDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _addressService.CreateAddressAsync(addressDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing address.
        /// </summary>
        /// <param name="id">Address ID</param>
        /// <param name="addressDto">Updated address data</param>
        /// <returns>Updated address</returns>
        /// <response code="200">Address updated successfully</response>
        /// <response code="400">Invalid input data</response>
        /// <response code="404">Address not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(AddressDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDTO>> Update([FromRoute] int id, [FromBody] AddressDTO addressDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _addressService.UpdateAddressAsync(id, addressDto);
            if (updated == null)
                return NotFound(new { message = $"Address with ID {id} not found." });

            return Ok(updated);
        }

        /// <summary>
        /// Deletes an address.
        /// </summary>
        /// <param name="id">Address ID</param>
        /// <returns>No content</returns>
        /// <response code="204">Address deleted successfully</response>
        /// <response code="404">Address not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _addressService.DeleteAddressAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Address with ID {id} not found." });

            return NoContent();
        }
    }
}

