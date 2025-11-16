using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    /// <summary>
    /// Service interface for Course business logic operations.
    /// </summary>
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> GetCourseByIdAsync(int id);
        Task<IEnumerable<CourseDTO>> GetCoursesByInstructorIdAsync(int instructorId);
        Task<CourseDTO> CreateCourseAsync(CourseDTO courseDto);
        Task<CourseDTO?> UpdateCourseAsync(int id, CourseDTO courseDto);
        Task<bool> DeleteCourseAsync(int id);
    }
}

