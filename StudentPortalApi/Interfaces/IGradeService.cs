using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    /// <summary>
    /// Service interface for Grade business logic operations.
    /// </summary>
    public interface IGradeService
    {
        Task<IEnumerable<GradeDTO>> GetAllGradesAsync();
        Task<GradeDTO?> GetGradeByIdAsync(int id);
        Task<IEnumerable<GradeDTO>> GetGradesByStudentIdAsync(int studentId);
        Task<IEnumerable<GradeDTO>> GetGradesByCourseIdAsync(int courseId);
        Task<GradeDTO> CreateGradeAsync(GradeDTO gradeDto);
        Task<GradeDTO?> UpdateGradeAsync(int id, GradeDTO gradeDto);
        Task<bool> DeleteGradeAsync(int id);
    }
}

