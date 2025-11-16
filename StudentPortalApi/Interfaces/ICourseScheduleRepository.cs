using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    public interface ICourseScheduleRepository
    {
        Task<IEnumerable<CourseScheduleDTO>> GetAllCourseSchedulesAsync();
        Task<CourseScheduleDTO?> GetCourseScheduleByIdAsync(int id);
        Task<IEnumerable<CourseScheduleDTO>> GetCourseSchedulesByCourseIdAsync(int courseId);
        Task<CourseScheduleDTO> AddCourseScheduleAsync(CourseScheduleDTO courseScheduleDto);
        Task<CourseScheduleDTO?> UpdateCourseScheduleAsync(int id, CourseScheduleDTO courseScheduleDto);
        Task<bool> DeleteCourseScheduleAsync(int id);
    }
}

