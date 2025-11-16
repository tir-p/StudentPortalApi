using System.ComponentModel.DataAnnotations;
using StudentPortalApi.Enums;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Data Transfer Object for Grade.
    /// DTOs are used to control what data is exposed to API consumers and prevent over-posting attacks.
    /// </summary>
    public class GradeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student ID is required")]
        public int StudentId { get; set; }

        // Optional: Include student name for display
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Course ID is required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters")]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course code is required")]
        [StringLength(20, ErrorMessage = "Course code cannot exceed 20 characters")]
        public string CourseCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Semester is required")]
        [StringLength(20, ErrorMessage = "Semester cannot exceed 20 characters")]
        public string Semester { get; set; } = string.Empty;

        [Required(ErrorMessage = "Total score is required")]
        [Range(0.0, 100.0, ErrorMessage = "Total score must be between 0.0 and 100.0")]
        public double TotalScore { get; set; }

        [Required(ErrorMessage = "Letter grade is required")]
        public LetterGrade LetterGrade { get; set; }

        [Required(ErrorMessage = "Grade points are required")]
        [Range(0.0, 4.0, ErrorMessage = "Grade points must be between 0.0 and 4.0")]
        public double GradePoints { get; set; }

        [Required(ErrorMessage = "Credits are required")]
        [Range(1, 60, ErrorMessage = "Credits must be between 1 and 60")]
        public int Credits { get; set; }
    }
}

