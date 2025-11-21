using System;
using System.ComponentModel.DataAnnotations;
using StudentPortalApi.Enums;

namespace StudentPortalApi.Models
{
    /// <summary>
    /// Represents a graded artifact (exam, project, lab, etc.) that contributes to a
    /// course grade, including weighting metadata for GPA calculations.
    /// </summary>
    public class Assignment
    {
        [Key]
        public int Id { get; set; } // int ID

        [Required]
        public int? GradeId { get; set; } // FK

        [Required]
        public string Name { get; set; }

        public double MaxScore { get; set; }
        public double EarnedScore { get; set; }
        public double Weight { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public AssignmentStatus Status { get; set; }
        public string? Feedback { get; set; }

        // Navigation
        public Grade? Grade { get; set; }
    }
}
