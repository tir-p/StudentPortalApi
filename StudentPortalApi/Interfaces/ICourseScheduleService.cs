using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    public interface ICourseScheduleService
    {
        Task<IEnumerable<CourseScheduleDTO>> GetAllCourseSchedulesAsync();
        Task<CourseScheduleDTO?> GetCourseScheduleByIdAsync(int id);
        Task<IEnumerable<CourseScheduleDTO>> GetCourseSchedulesByCourseIdAsync(int courseId);
        Task<CourseScheduleDTO> CreateCourseScheduleAsync(CourseScheduleDTO courseScheduleDto);
        Task<CourseScheduleDTO?> UpdateCourseScheduleAsync(int id, CourseScheduleDTO courseScheduleDto);
        Task<bool> DeleteCourseScheduleAsync(int id);
    }
}

