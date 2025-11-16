using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    /// <summary>
    /// Repository interface for Course data access operations.
    /// </summary>
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> GetCourseByIdAsync(int id);
        Task<IEnumerable<CourseDTO>> GetCoursesByInstructorIdAsync(int instructorId);
        Task<CourseDTO> AddCourseAsync(CourseDTO courseDto);
        Task<CourseDTO?> UpdateCourseAsync(int id, CourseDTO courseDto);
        Task<bool> DeleteCourseAsync(int id);
    }
}

