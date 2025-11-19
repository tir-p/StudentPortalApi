using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Api.Data;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    /// <summary>
    /// Handles persistence for granular attendance records.
    /// </summary>
    public class AttendanceRecordRepository : IAttendanceRecordRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public AttendanceRecordRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceRecordDTO>> GetAllAttendanceRecordsAsync()
        {
            var records = await _dbContext.AttendanceRecords
                .Include(ar => ar.Attendance)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AttendanceRecordDTO>>(records);
        }

        public async Task<AttendanceRecordDTO?> GetAttendanceRecordByIdAsync(int id)
        {
            var record = await _dbContext.AttendanceRecords
                .Include(ar => ar.Attendance)
                .FirstOrDefaultAsync(ar => ar.Id == id);

            return record == null ? null : _mapper.Map<AttendanceRecordDTO>(record);
        }

        public async Task<IEnumerable<AttendanceRecordDTO>> GetAttendanceRecordsByAttendanceIdAsync(int attendanceId)
        {
            var records = await _dbContext.AttendanceRecords
                .Include(ar => ar.Attendance)
                .Where(ar => ar.AttendanceId == attendanceId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AttendanceRecordDTO>>(records);
        }

        public async Task<AttendanceRecordDTO> AddAttendanceRecordAsync(AttendanceRecordDTO attendanceRecordDto)
        {
            var record = _mapper.Map<AttendanceRecord>(attendanceRecordDto);
            _dbContext.AttendanceRecords.Add(record);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AttendanceRecordDTO>(record);
        }

        public async Task<AttendanceRecordDTO?> UpdateAttendanceRecordAsync(int id, AttendanceRecordDTO attendanceRecordDto)
        {
            var record = await _dbContext.AttendanceRecords.FindAsync(id);
            if (record == null) return null;

            _mapper.Map(attendanceRecordDto, record);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<AttendanceRecordDTO>(record);
        }

        public async Task<bool> DeleteAttendanceRecordAsync(int id)
        {
            var record = await _dbContext.AttendanceRecords.FindAsync(id);
            if (record == null) return false;

            _dbContext.AttendanceRecords.Remove(record);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

