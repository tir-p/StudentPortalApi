using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Service implementation for Course business logic.
    /// This layer handles business rules, validation, and orchestrates repository calls.
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _courseRepository.GetCourseByIdAsync(id);
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByInstructorIdAsync(int instructorId)
        {
            if (instructorId <= 0)
                return Enumerable.Empty<CourseDTO>();

            return await _courseRepository.GetCoursesByInstructorIdAsync(instructorId);
        }

        public async Task<CourseDTO> CreateCourseAsync(CourseDTO courseDto)
        {
            // Business logic validation can be added here
            // For example: Check if instructor exists, validate course code uniqueness, etc.
            
            return await _courseRepository.AddCourseAsync(courseDto);
        }

        public async Task<CourseDTO?> UpdateCourseAsync(int id, CourseDTO courseDto)
        {
            if (id <= 0)
                return null;

            // Business logic validation can be added here
            return await _courseRepository.UpdateCourseAsync(id, courseDto);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _courseRepository.DeleteCourseAsync(id);
        }
    }
}

