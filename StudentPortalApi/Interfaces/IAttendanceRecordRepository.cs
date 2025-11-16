using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    public interface IAttendanceRecordRepository
    {
        Task<IEnumerable<AttendanceRecordDTO>> GetAllAttendanceRecordsAsync();
        Task<AttendanceRecordDTO?> GetAttendanceRecordByIdAsync(int id);
        Task<IEnumerable<AttendanceRecordDTO>> GetAttendanceRecordsByAttendanceIdAsync(int attendanceId);
        Task<AttendanceRecordDTO> AddAttendanceRecordAsync(AttendanceRecordDTO attendanceRecordDto);
        Task<AttendanceRecordDTO?> UpdateAttendanceRecordAsync(int id, AttendanceRecordDTO attendanceRecordDto);
        Task<bool> DeleteAttendanceRecordAsync(int id);
    }
}

