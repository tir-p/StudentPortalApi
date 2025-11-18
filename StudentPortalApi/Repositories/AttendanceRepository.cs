using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.DTOs;
using StudentPortalApi.DTOs.Data;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    /// <summary>
    /// Concrete data-access implementation for attendance summaries using EF Core.
    /// </summary>
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public AttendanceRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAllAttendancesAsync()
        {
            var attendances = await _dbContext.Attendances
                .Include(a => a.Records)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
        }

        public async Task<AttendanceDTO?> GetAttendanceByIdAsync(int id)
        {
            var attendance = await _dbContext.Attendances
                .Include(a => a.Records)
                .FirstOrDefaultAsync(a => a.Id == id);

            return attendance == null ? null : _mapper.Map<AttendanceDTO>(attendance);
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId)
        {
            var attendances = await _dbContext.Attendances
                .Include(a => a.Records)
                .Where(a => a.StudentId == studentId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByCourseIdAsync(int courseId)
        {
            var attendances = await _dbContext.Attendances
                .Include(a => a.Records)
                .Where(a => a.CourseId == courseId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
        }

        public async Task<AttendanceDTO> AddAttendanceAsync(AttendanceDTO attendanceDto)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            _dbContext.Attendances.Add(attendance);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AttendanceDTO>(attendance);
        }

        public async Task<AttendanceDTO?> UpdateAttendanceAsync(int id, AttendanceDTO attendanceDto)
        {
            var attendance = await _dbContext.Attendances.FindAsync(id);
            if (attendance == null) return null;

            _mapper.Map(attendanceDto, attendance);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<AttendanceDTO>(attendance);
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var attendance = await _dbContext.Attendances.FindAsync(id);
            if (attendance == null) return false;

            _dbContext.Attendances.Remove(attendance);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

