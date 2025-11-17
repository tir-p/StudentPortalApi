using StudentPortalApi.Enums;
using StudentPortalApi.Models;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a single attendance entry for a given class meeting,
/// capturing punctuality, modality, and instructor remarks for analytics.
/// </summary>
public class AttendanceRecord
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [EnumDataType(typeof(AttendanceRecordStatus))]
    public AttendanceRecordStatus Status { get; set; }

    [MaxLength(300)]
    public string? Remarks { get; set; }

    [Required]
    [EnumDataType(typeof(ClassType))]
    public ClassType ClassType { get; set; }

    // FK for Attendance
    public int AttendanceId { get; set; }  // <- FK property
    public Attendance? Attendance { get; set; }  // <- Navigation
}
