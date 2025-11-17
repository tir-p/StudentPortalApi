using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortalApi.Models
{
    /// <summary>
    /// Entity representing the mailing location tied to a student; stored separately
    /// to keep contact data decoupled from academic information while still
    /// supporting a strict one-to-one relationship.
    /// </summary>
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; } // <-- Add this FK

        [Required]
        [MaxLength(150)]
        [Column("Street")]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("City")]
        public string City { get; set; }

        [MaxLength(100)]
        [Column("State")]
        public string? State { get; set; }

        [MaxLength(20)]
        [Column("ZipCode")]
        public string? ZipCode { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Country")]
        public string Country { get; set; }

        // Navigation property
        public Student? Student { get; set; }
    }
}
