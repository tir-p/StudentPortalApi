using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentPortalApi.Enums;

namespace StudentPortalApi.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; } // int ID

        [Required]
        public int StudentId { get; set; } // FK

        [Required]
        public int CourseId { get; set; } // FK

        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Semester { get; set; }
        public double TotalScore { get; set; }
        public LetterGrade LetterGrade { get; set; }
        public double GradePoints { get; set; }
        public int Credits { get; set; }

        // Navigation
        public Student Student { get; set; }
        public Course Course { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
