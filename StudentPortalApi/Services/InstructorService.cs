using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Service implementation for Instructor business logic.
    /// This layer handles business rules, validation, and orchestrates repository calls.
    /// </summary>
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<InstructorDTO>> GetAllInstructorsAsync()
        {
            return await _instructorRepository.GetAllInstructorsAsync();
        }

        public async Task<InstructorDTO?> GetInstructorByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _instructorRepository.GetInstructorByIdAsync(id);
        }

        public async Task<InstructorDTO> CreateInstructorAsync(InstructorDTO instructorDto)
        {
            // Business logic validation can be added here
            // For example: Check if email already exists, validate department, etc.
            
            return await _instructorRepository.AddInstructorAsync(instructorDto);
        }

        public async Task<InstructorDTO?> UpdateInstructorAsync(int id, InstructorDTO instructorDto)
        {
            if (id <= 0)
                return null;

            // Business logic validation can be added here
            return await _instructorRepository.UpdateInstructorAsync(id, instructorDto);
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _instructorRepository.DeleteInstructorAsync(id);
        }
    }
}

