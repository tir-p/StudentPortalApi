using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    /// <summary>
    /// Repository interface for Instructor data access operations.
    /// </summary>
    public interface IInstructorRepository
    {
        Task<IEnumerable<InstructorDTO>> GetAllInstructorsAsync();
        Task<InstructorDTO?> GetInstructorByIdAsync(int id);
        Task<InstructorDTO> AddInstructorAsync(InstructorDTO instructorDto);
        Task<InstructorDTO?> UpdateInstructorAsync(int id, InstructorDTO instructorDto);
        Task<bool> DeleteInstructorAsync(int id);
    }
}

