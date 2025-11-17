using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.Data;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    /// <summary>
    /// Provides data access for course schedule entities.
    /// </summary>
    public class CourseScheduleRepository : ICourseScheduleRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public CourseScheduleRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseScheduleDTO>> GetAllCourseSchedulesAsync()
        {
            var schedules = await _dbContext.CourseSchedules
                .Include(cs => cs.Course)
                .ToListAsync();

            var scheduleDtos = _mapper.Map<IEnumerable<CourseScheduleDTO>>(schedules);
            foreach (var scheduleDto in scheduleDtos)
            {
                var schedule = schedules.First(s => s.Id == scheduleDto.Id);
                scheduleDto.CourseName = schedule.Course?.Name;
            }

            return scheduleDtos;
        }

        public async Task<CourseScheduleDTO?> GetCourseScheduleByIdAsync(int id)
        {
            var schedule = await _dbContext.CourseSchedules
                .Include(cs => cs.Course)
                .FirstOrDefaultAsync(cs => cs.Id == id);

            if (schedule == null) return null;

            var scheduleDto = _mapper.Map<CourseScheduleDTO>(schedule);
            scheduleDto.CourseName = schedule.Course?.Name;
            return scheduleDto;
        }

        public async Task<IEnumerable<CourseScheduleDTO>> GetCourseSchedulesByCourseIdAsync(int courseId)
        {
            var schedules = await _dbContext.CourseSchedules
                .Include(cs => cs.Course)
                .Where(cs => cs.CourseId == courseId)
                .ToListAsync();

            var scheduleDtos = _mapper.Map<IEnumerable<CourseScheduleDTO>>(schedules);
            foreach (var scheduleDto in scheduleDtos)
            {
                var schedule = schedules.First(s => s.Id == scheduleDto.Id);
                scheduleDto.CourseName = schedule.Course?.Name;
            }

            return scheduleDtos;
        }

        public async Task<CourseScheduleDTO> AddCourseScheduleAsync(CourseScheduleDTO courseScheduleDto)
        {
            var schedule = _mapper.Map<CourseSchedule>(courseScheduleDto);
            _dbContext.CourseSchedules.Add(schedule);
            await _dbContext.SaveChangesAsync();
            
            await _dbContext.Entry(schedule).Reference(cs => cs.Course).LoadAsync();
            var result = _mapper.Map<CourseScheduleDTO>(schedule);
            result.CourseName = schedule.Course?.Name;
            return result;
        }

        public async Task<CourseScheduleDTO?> UpdateCourseScheduleAsync(int id, CourseScheduleDTO courseScheduleDto)
        {
            var schedule = await _dbContext.CourseSchedules
                .Include(cs => cs.Course)
                .FirstOrDefaultAsync(cs => cs.Id == id);

            if (schedule == null) return null;

            _mapper.Map(courseScheduleDto, schedule);
            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<CourseScheduleDTO>(schedule);
            result.CourseName = schedule.Course?.Name;
            return result;
        }

        public async Task<bool> DeleteCourseScheduleAsync(int id)
        {
            var schedule = await _dbContext.CourseSchedules.FindAsync(id);
            if (schedule == null) return false;

            _dbContext.CourseSchedules.Remove(schedule);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

