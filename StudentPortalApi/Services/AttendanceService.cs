using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAttendancesAsync();
        }

        public async Task<AttendanceDTO?> GetAttendanceByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _attendanceRepository.GetAttendanceByIdAsync(id);
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId)
        {
            if (studentId <= 0) return Enumerable.Empty<AttendanceDTO>();
            return await _attendanceRepository.GetAttendancesByStudentIdAsync(studentId);
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByCourseIdAsync(int courseId)
        {
            if (courseId <= 0) return Enumerable.Empty<AttendanceDTO>();
            return await _attendanceRepository.GetAttendancesByCourseIdAsync(courseId);
        }

        public async Task<AttendanceDTO> CreateAttendanceAsync(AttendanceDTO attendanceDto)
        {
            return await _attendanceRepository.AddAttendanceAsync(attendanceDto);
        }

        public async Task<AttendanceDTO?> UpdateAttendanceAsync(int id, AttendanceDTO attendanceDto)
        {
            if (id <= 0) return null;
            return await _attendanceRepository.UpdateAttendanceAsync(id, attendanceDto);
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            if (id <= 0) return false;
            return await _attendanceRepository.DeleteAttendanceAsync(id);
        }
    }
}

