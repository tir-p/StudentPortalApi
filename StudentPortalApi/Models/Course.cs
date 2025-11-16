using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentPortalApi.Enums;

namespace StudentPortalApi.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(1, 60)]
        public int Credits { get; set; }

        [Required]
        [StringLength(20)]
        public string Semester { get; set; }

        // Instructor FK
        [Required]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        // CourseSchedules
        public List<CourseSchedule> Schedule { get; set; } = new();

        // Grades navigation
        public List<Grade> Grades { get; set; } = new();

        [Range(0, int.MaxValue)]
        public int EnrolledStudents { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxCapacity { get; set; }

        [Required]
        public CourseStatus Status { get; set; }

        [StringLength(500)]
        public string? Syllabus { get; set; }
    }
}
