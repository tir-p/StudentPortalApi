using System.ComponentModel.DataAnnotations;
using StudentPortalApi.Enums;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Data Transfer Object for Course.
    /// DTOs are used to control what data is exposed to API consumers and prevent over-posting attacks.
    /// </summary>
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course code is required")]
        [StringLength(20, ErrorMessage = "Course code cannot exceed 20 characters")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Credits are required")]
        [Range(1, 60, ErrorMessage = "Credits must be between 1 and 60")]
        public int Credits { get; set; }

        [Required(ErrorMessage = "Semester is required")]
        [StringLength(20, ErrorMessage = "Semester cannot exceed 20 characters")]
        public string Semester { get; set; } = string.Empty;

        [Required(ErrorMessage = "Instructor ID is required")]
        public int InstructorId { get; set; }

        // Optional: Include instructor name for display
        public string? InstructorName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Enrolled students cannot be negative")]
        public int EnrolledStudents { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Max capacity must be at least 1")]
        public int MaxCapacity { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public CourseStatus Status { get; set; }

        [StringLength(500, ErrorMessage = "Syllabus cannot exceed 500 characters")]
        public string? Syllabus { get; set; }

        // Nested objects for frontend
        public InstructorDTO? Instructor { get; set; }
        public List<CourseScheduleDTO>? Schedule { get; set; }
    }
}

