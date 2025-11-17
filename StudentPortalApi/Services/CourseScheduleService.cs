using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Business logic layer for managing course schedule entries.
    /// </summary>
    public class CourseScheduleService : ICourseScheduleService
    {
        private readonly ICourseScheduleRepository _courseScheduleRepository;

        public CourseScheduleService(ICourseScheduleRepository courseScheduleRepository)
        {
            _courseScheduleRepository = courseScheduleRepository;
        }

        /// <summary>
        /// Returns all schedule entries.
        /// </summary>
        public async Task<IEnumerable<CourseScheduleDTO>> GetAllCourseSchedulesAsync()
        {
            return await _courseScheduleRepository.GetAllCourseSchedulesAsync();
        }

        /// <summary>
        /// Retrieves a schedule entry by identifier.
        /// </summary>
        public async Task<CourseScheduleDTO?> GetCourseScheduleByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _courseScheduleRepository.GetCourseScheduleByIdAsync(id);
        }

        /// <summary>
        /// Returns schedule entries belonging to the specified course.
        /// </summary>
        public async Task<IEnumerable<CourseScheduleDTO>> GetCourseSchedulesByCourseIdAsync(int courseId)
        {
            if (courseId <= 0) return Enumerable.Empty<CourseScheduleDTO>();
            return await _courseScheduleRepository.GetCourseSchedulesByCourseIdAsync(courseId);
        }

        /// <summary>
        /// Creates a new schedule entry.
        /// </summary>
        public async Task<CourseScheduleDTO> CreateCourseScheduleAsync(CourseScheduleDTO courseScheduleDto)
        {
            return await _courseScheduleRepository.AddCourseScheduleAsync(courseScheduleDto);
        }

        /// <summary>
        /// Updates an existing schedule entry.
        /// </summary>
        public async Task<CourseScheduleDTO?> UpdateCourseScheduleAsync(int id, CourseScheduleDTO courseScheduleDto)
        {
            if (id <= 0) return null;
            return await _courseScheduleRepository.UpdateCourseScheduleAsync(id, courseScheduleDto);
        }

        /// <summary>
        /// Deletes a schedule entry by ID.
        /// </summary>
        public async Task<bool> DeleteCourseScheduleAsync(int id)
        {
            if (id <= 0) return false;
            return await _courseScheduleRepository.DeleteCourseScheduleAsync(id);
        }
    }
}

