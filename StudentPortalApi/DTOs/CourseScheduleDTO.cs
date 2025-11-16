using System.ComponentModel.DataAnnotations;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Data Transfer Object for CourseSchedule.
    /// </summary>
    public class CourseScheduleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course ID is required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Day is required")]
        [StringLength(15, ErrorMessage = "Day cannot exceed 15 characters")]
        public string Day { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start time is required")]
        [StringLength(10, ErrorMessage = "Start time cannot exceed 10 characters")]
        public string StartTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "End time is required")]
        [StringLength(10, ErrorMessage = "End time cannot exceed 10 characters")]
        public string EndTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters")]
        public string Location { get; set; } = string.Empty;

        // Optional: Include course name for display
        public string? CourseName { get; set; }
    }
}

