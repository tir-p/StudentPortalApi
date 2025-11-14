using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentPortalApi.Enums;

namespace StudentPortalApi.Models
{
    public class Attendance
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("StudentId")]
        public int StudentId { get; set; }

        [Required]
        [Column("CourseId")]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("CourseName")]
        public string CourseName { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("CourseCode")]
        public string CourseCode { get; set; }

        // Navigation property
        public List<AttendanceRecord> Records { get; set; } = new();

        [Range(0, int.MaxValue)]
        [Column("TotalClasses")]
        public int TotalClasses { get; set; }

        [Range(0, int.MaxValue)]
        [Column("AttendedClasses")]
        public int AttendedClasses { get; set; }

        [Range(0, 100)]
        [Column("AttendancePercentage")]
        public double AttendancePercentage { get; set; }

        [Required]
        [EnumDataType(typeof(AttendanceStatus))]
        [Column("Status")]
        public AttendanceStatus Status { get; set; }
    }
}
