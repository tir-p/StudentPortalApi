using StudentPortal.Application.DTOs;

namespace StudentPortal.Application.Interfaces
{
    /// <summary>
    /// Service interface for Instructor business logic operations.
    /// </summary>
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorDTO>> GetAllInstructorsAsync();
        Task<InstructorDTO?> GetInstructorByIdAsync(int id);
        Task<InstructorDTO> CreateInstructorAsync(InstructorDTO instructorDto);
        Task<InstructorDTO?> UpdateInstructorAsync(int id, InstructorDTO instructorDto);
        Task<bool> DeleteInstructorAsync(int id);
    }
}

