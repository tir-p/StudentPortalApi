using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    /// <summary>
    /// Repository interface for Grade data access operations.
    /// </summary>
    public interface IGradeRepository
    {
        Task<IEnumerable<GradeDTO>> GetAllGradesAsync();
        Task<GradeDTO?> GetGradeByIdAsync(int id);
        Task<IEnumerable<GradeDTO>> GetGradesByStudentIdAsync(int studentId);
        Task<IEnumerable<GradeDTO>> GetGradesByCourseIdAsync(int courseId);
        Task<GradeDTO> AddGradeAsync(GradeDTO gradeDto);
        Task<GradeDTO?> UpdateGradeAsync(int id, GradeDTO gradeDto);
        Task<bool> DeleteGradeAsync(int id);
    }
}

