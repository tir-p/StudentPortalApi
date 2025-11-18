using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.DTOs;
using StudentPortalApi.DTOs.Data;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    /// <summary>
    /// Repository implementation for Course data access operations.
    /// Uses async/await for all database operations to prevent thread blocking and improve scalability.
    /// </summary>
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public CourseRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _dbContext.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Schedule)
                .ToListAsync();

            var courseDtos = _mapper.Map<IEnumerable<CourseDTO>>(courses);
            
            // Map instructor and schedule
            foreach (var courseDto in courseDtos)
            {
                var course = courses.First(c => c.Id == courseDto.Id);
                courseDto.InstructorName = course.Instructor?.Name;
                // Instructor and Schedule are already mapped by AutoMapper
            }

            return courseDtos;
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int id)
        {
            var course = await _dbContext.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Schedule)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return null;

            var courseDto = _mapper.Map<CourseDTO>(course);
            courseDto.InstructorName = course.Instructor?.Name;
            // Instructor and Schedule are already mapped by AutoMapper
            return courseDto;
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByInstructorIdAsync(int instructorId)
        {
            var courses = await _dbContext.Courses
                .Include(c => c.Instructor)
                .Where(c => c.InstructorId == instructorId)
                .ToListAsync();

            var courseDtos = _mapper.Map<IEnumerable<CourseDTO>>(courses);
            
            foreach (var courseDto in courseDtos)
            {
                var course = courses.First(c => c.Id == courseDto.Id);
                courseDto.InstructorName = course.Instructor?.Name;
            }

            return courseDtos;
        }

        public async Task<CourseDTO> AddCourseAsync(CourseDTO courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
            
            // Reload with instructor to get name
            await _dbContext.Entry(course).Reference(c => c.Instructor).LoadAsync();
            var result = _mapper.Map<CourseDTO>(course);
            result.InstructorName = course.Instructor?.Name;
            return result;
        }

        public async Task<CourseDTO?> UpdateCourseAsync(int id, CourseDTO courseDto)
        {
            var course = await _dbContext.Courses
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return null;

            _mapper.Map(courseDto, course);
            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<CourseDTO>(course);
            result.InstructorName = course.Instructor?.Name;
            return result;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            if (course == null) return false;

            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

