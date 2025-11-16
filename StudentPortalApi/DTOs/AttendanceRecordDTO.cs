using System;
using System.ComponentModel.DataAnnotations;
using StudentPortalApi.Enums;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Data Transfer Object for AttendanceRecord.
    /// </summary>
    public class AttendanceRecordDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Attendance ID is required")]
        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public AttendanceRecordStatus Status { get; set; }

        [StringLength(300, ErrorMessage = "Remarks cannot exceed 300 characters")]
        public string? Remarks { get; set; }

        [Required(ErrorMessage = "Class type is required")]
        public ClassType ClassType { get; set; }
    }
}

