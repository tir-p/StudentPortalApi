using System.ComponentModel.DataAnnotations;
using StudentPortalApi.Enums;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Data Transfer Object for Attendance.
    /// </summary>
    public class AttendanceDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student ID is required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Course ID is required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(150, ErrorMessage = "Course name cannot exceed 150 characters")]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course code is required")]
        [StringLength(20, ErrorMessage = "Course code cannot exceed 20 characters")]
        public string CourseCode { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Total classes cannot be negative")]
        public int TotalClasses { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Attended classes cannot be negative")]
        public int AttendedClasses { get; set; }

        [Range(0.0, 100.0, ErrorMessage = "Attendance percentage must be between 0.0 and 100.0")]
        public double AttendancePercentage { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public AttendanceStatus Status { get; set; }

        // Nested records for frontend
        public List<AttendanceRecordDTO>? Records { get; set; }
    }
}

