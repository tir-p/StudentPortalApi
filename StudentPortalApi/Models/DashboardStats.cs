using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortalApi.Models
{
    public class DashboardStats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; } // optional PK if stored in DB

        [Required]
        [MaxLength(20)]
        [Column("CurrentSemester")]
        public string CurrentSemester { get; set; }

        [Required]
        [Column("CurrentGPA")]
        public double CurrentGPA { get; set; }

        [Required]
        [Column("TotalCredits")]
        public int TotalCredits { get; set; }

        [Required]
        [Column("AttendanceRate")]
        public double AttendanceRate { get; set; }

        [Required]
        [Column("UpcomingAssignments")]
        public int UpcomingAssignments { get; set; }

        [Required]
        [Column("ActiveCourses")]
        public int ActiveCourses { get; set; }

        [Required]
        [Column("TotalCourses")]
        public int TotalCourses { get; set; }

        // Navigation property
        public List<UpcomingEvent> RecentActivities { get; set; } = new();
    }
}
