using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortalApi.Models
{
    /// <summary>
    /// Represents teaching staff metadata used for course assignments and contact details.
    /// </summary>
    public class Instructor
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Department")]
        public string Department { get; set; }

        [StringLength(200)]
        [Column("OfficeHours")]
        public string? OfficeHours { get; set; } // optional
    }
}
