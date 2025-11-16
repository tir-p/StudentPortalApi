using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<AttendanceDTO>> GetAllAttendancesAsync();
        Task<AttendanceDTO?> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesByCourseIdAsync(int courseId);
        Task<AttendanceDTO> AddAttendanceAsync(AttendanceDTO attendanceDto);
        Task<AttendanceDTO?> UpdateAttendanceAsync(int id, AttendanceDTO attendanceDto);
        Task<bool> DeleteAttendanceAsync(int id);
    }
}

