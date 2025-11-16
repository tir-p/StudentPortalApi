using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    /// <summary>
    /// Service interface for Student business logic operations.
    /// This layer abstracts business logic from data access, following the Service-Repository pattern.
    /// </summary>
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO?> GetStudentByIdAsync(int id);
        Task<StudentDTO> CreateStudentAsync(StudentDTO studentDto);
        Task<StudentDTO?> UpdateStudentAsync(int id, StudentDTO studentDto);
        Task<bool> DeleteStudentAsync(int id);
    }
}

