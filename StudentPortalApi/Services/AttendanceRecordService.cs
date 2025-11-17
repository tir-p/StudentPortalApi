using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Encapsulates business behavior for fine-grained attendance records.
    /// </summary>
    public class AttendanceRecordService : IAttendanceRecordService
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public AttendanceRecordService(IAttendanceRecordRepository attendanceRecordRepository)
        {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        /// <summary>
        /// Returns every detailed attendance entry in the system.
        /// </summary>
        public async Task<IEnumerable<AttendanceRecordDTO>> GetAllAttendanceRecordsAsync()
        {
            return await _attendanceRecordRepository.GetAllAttendanceRecordsAsync();
        }

        /// <summary>
        /// Retrieves a single attendance record by identifier.
        /// </summary>
        public async Task<AttendanceRecordDTO?> GetAttendanceRecordByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _attendanceRecordRepository.GetAttendanceRecordByIdAsync(id);
        }

        /// <summary>
        /// Gets all records that belong to the specified attendance summary.
        /// </summary>
        public async Task<IEnumerable<AttendanceRecordDTO>> GetAttendanceRecordsByAttendanceIdAsync(int attendanceId)
        {
            if (attendanceId <= 0) return Enumerable.Empty<AttendanceRecordDTO>();
            return await _attendanceRecordRepository.GetAttendanceRecordsByAttendanceIdAsync(attendanceId);
        }

        /// <summary>
        /// Creates a new attendance record entity.
        /// </summary>
        public async Task<AttendanceRecordDTO> CreateAttendanceRecordAsync(AttendanceRecordDTO attendanceRecordDto)
        {
            return await _attendanceRecordRepository.AddAttendanceRecordAsync(attendanceRecordDto);
        }

        /// <summary>
        /// Updates a previously stored attendance record when a valid ID is provided.
        /// </summary>
        public async Task<AttendanceRecordDTO?> UpdateAttendanceRecordAsync(int id, AttendanceRecordDTO attendanceRecordDto)
        {
            if (id <= 0) return null;
            return await _attendanceRecordRepository.UpdateAttendanceRecordAsync(id, attendanceRecordDto);
        }

        /// <summary>
        /// Deletes a single attendance record by ID; returns false if the record is missing.
        /// </summary>
        public async Task<bool> DeleteAttendanceRecordAsync(int id)
        {
            if (id <= 0) return false;
            return await _attendanceRecordRepository.DeleteAttendanceRecordAsync(id);
        }
    }
}

