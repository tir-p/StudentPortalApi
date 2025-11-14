using StudentPortalApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class CourseSchedule
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, StringLength(15)]
    public string Day { get; set; }

    [Required, StringLength(10)]
    public string StartTime { get; set; }

    [Required, StringLength(10)]
    public string EndTime { get; set; }

    [Required, StringLength(100)]
    public string Location { get; set; }

    // FK for Course
    public int CourseId { get; set; }  // <- FK property
    public Course? Course { get; set; }   // <- Navigation
}
