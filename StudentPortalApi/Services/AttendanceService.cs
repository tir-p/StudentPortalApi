using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Coordinates attendance-specific business rules before delegating to the repository layer.
    /// </summary>
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        /// <summary>
        /// Returns every attendance aggregate in the system; mainly used for admin dashboards.
        /// </summary>
        public async Task<IEnumerable<AttendanceDTO>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAttendancesAsync();
        }

        /// <summary>
        /// Look up a single attendance record set by its identifier.
        /// </summary>
        public async Task<AttendanceDTO?> GetAttendanceByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _attendanceRepository.GetAttendanceByIdAsync(id);
        }

        /// <summary>
        /// Fetches attendance summaries for a particular student across all courses.
        /// </summary>
        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId)
        {
            if (studentId <= 0) return Enumerable.Empty<AttendanceDTO>();
            return await _attendanceRepository.GetAttendancesByStudentIdAsync(studentId);
        }

        /// <summary>
        /// Fetches attendance summaries for a specific course across all students.
        /// </summary>
        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByCourseIdAsync(int courseId)
        {
            if (courseId <= 0) return Enumerable.Empty<AttendanceDTO>();
            return await _attendanceRepository.GetAttendancesByCourseIdAsync(courseId);
        }

        /// <summary>
        /// Persists a new attendance summary row; validations handled upstream via data annotations.
        /// </summary>
        public async Task<AttendanceDTO> CreateAttendanceAsync(AttendanceDTO attendanceDto)
        {
            return await _attendanceRepository.AddAttendanceAsync(attendanceDto);
        }

        /// <summary>
        /// Updates an existing attendance summary after guarding invalid identifiers.
        /// </summary>
        public async Task<AttendanceDTO?> UpdateAttendanceAsync(int id, AttendanceDTO attendanceDto)
        {
            if (id <= 0) return null;
            return await _attendanceRepository.UpdateAttendanceAsync(id, attendanceDto);
        }

        /// <summary>
        /// Deletes an attendance summary by ID; returns false when the record is not found.
        /// </summary>
        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            if (id <= 0) return false;
            return await _attendanceRepository.DeleteAttendanceAsync(id);
        }
    }
}

