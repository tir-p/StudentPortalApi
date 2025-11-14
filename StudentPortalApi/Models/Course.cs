using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentPortalApi.Enums;

namespace StudentPortalApi.Models
{
    public class Course
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Code")]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Range(1, 60)]
        [Column("Credits")]
        public int Credits { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Semester")]
        public string Semester { get; set; }

        // Navigation to Instructor
        [Required]
        [ForeignKey("InstructorId")]
        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }

        // Navigation to CourseSchedule
        public List<CourseSchedule> Schedule { get; set; } = new();

        [Range(0, int.MaxValue)]
        [Column("EnrolledStudents")]
        public int EnrolledStudents { get; set; }

        [Range(1, int.MaxValue)]
        [Column("MaxCapacity")]
        public int MaxCapacity { get; set; }

        [Required]
        [EnumDataType(typeof(CourseStatus))]
        [Column("Status")]
        public CourseStatus Status { get; set; }

        [StringLength(500)]
        [Column("Syllabus")]
        public string? Syllabus { get; set; } // optional
    }
}
