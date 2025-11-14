using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentPortalApi.Enums;

namespace StudentPortalApi.Models
{
    public class UpcomingEvent
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Title")]
        public string Title { get; set; }

        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }

        [Required]
        [EnumDataType(typeof(EventType))]
        [Column("Type")]
        public EventType Type { get; set; }

        [MaxLength(20)]
        [Column("CourseCode")]
        public string? CourseCode { get; set; } // optional in TS

        [MaxLength(500)]
        [Column("Description")]
        public string? Description { get; set; } // optional in TS
    }
}
