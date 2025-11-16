using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    public class AttendanceRecordService : IAttendanceRecordService
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public AttendanceRecordService(IAttendanceRecordRepository attendanceRecordRepository)
        {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        public async Task<IEnumerable<AttendanceRecordDTO>> GetAllAttendanceRecordsAsync()
        {
            return await _attendanceRecordRepository.GetAllAttendanceRecordsAsync();
        }

        public async Task<AttendanceRecordDTO?> GetAttendanceRecordByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _attendanceRecordRepository.GetAttendanceRecordByIdAsync(id);
        }

        public async Task<IEnumerable<AttendanceRecordDTO>> GetAttendanceRecordsByAttendanceIdAsync(int attendanceId)
        {
            if (attendanceId <= 0) return Enumerable.Empty<AttendanceRecordDTO>();
            return await _attendanceRecordRepository.GetAttendanceRecordsByAttendanceIdAsync(attendanceId);
        }

        public async Task<AttendanceRecordDTO> CreateAttendanceRecordAsync(AttendanceRecordDTO attendanceRecordDto)
        {
            return await _attendanceRecordRepository.AddAttendanceRecordAsync(attendanceRecordDto);
        }

        public async Task<AttendanceRecordDTO?> UpdateAttendanceRecordAsync(int id, AttendanceRecordDTO attendanceRecordDto)
        {
            if (id <= 0) return null;
            return await _attendanceRecordRepository.UpdateAttendanceRecordAsync(id, attendanceRecordDto);
        }

        public async Task<bool> DeleteAttendanceRecordAsync(int id)
        {
            if (id <= 0) return false;
            return await _attendanceRecordRepository.DeleteAttendanceRecordAsync(id);
        }
    }
}

