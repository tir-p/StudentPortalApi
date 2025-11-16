using System;
using System.ComponentModel.DataAnnotations;
using StudentPortalApi.Enums;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Data Transfer Object for Assignment.
    /// </summary>
    public class AssignmentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Grade ID is required")]
        public int GradeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Range(0.0, double.MaxValue, ErrorMessage = "Max score cannot be negative")]
        public double MaxScore { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Earned score cannot be negative")]
        public double EarnedScore { get; set; }

        [Range(0.0, 100.0, ErrorMessage = "Weight must be between 0.0 and 100.0")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        [DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? SubmittedDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public AssignmentStatus Status { get; set; }

        [StringLength(1000, ErrorMessage = "Feedback cannot exceed 1000 characters")]
        public string? Feedback { get; set; }
    }
}

