using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    public class CourseScheduleService : ICourseScheduleService
    {
        private readonly ICourseScheduleRepository _courseScheduleRepository;

        public CourseScheduleService(ICourseScheduleRepository courseScheduleRepository)
        {
            _courseScheduleRepository = courseScheduleRepository;
        }

        public async Task<IEnumerable<CourseScheduleDTO>> GetAllCourseSchedulesAsync()
        {
            return await _courseScheduleRepository.GetAllCourseSchedulesAsync();
        }

        public async Task<CourseScheduleDTO?> GetCourseScheduleByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _courseScheduleRepository.GetCourseScheduleByIdAsync(id);
        }

        public async Task<IEnumerable<CourseScheduleDTO>> GetCourseSchedulesByCourseIdAsync(int courseId)
        {
            if (courseId <= 0) return Enumerable.Empty<CourseScheduleDTO>();
            return await _courseScheduleRepository.GetCourseSchedulesByCourseIdAsync(courseId);
        }

        public async Task<CourseScheduleDTO> CreateCourseScheduleAsync(CourseScheduleDTO courseScheduleDto)
        {
            return await _courseScheduleRepository.AddCourseScheduleAsync(courseScheduleDto);
        }

        public async Task<CourseScheduleDTO?> UpdateCourseScheduleAsync(int id, CourseScheduleDTO courseScheduleDto)
        {
            if (id <= 0) return null;
            return await _courseScheduleRepository.UpdateCourseScheduleAsync(id, courseScheduleDto);
        }

        public async Task<bool> DeleteCourseScheduleAsync(int id)
        {
            if (id <= 0) return false;
            return await _courseScheduleRepository.DeleteCourseScheduleAsync(id);
        }
    }
}

