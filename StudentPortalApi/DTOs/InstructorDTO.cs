using System.ComponentModel.DataAnnotations;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Data Transfer Object for Instructor.
    /// DTOs are used to control what data is exposed to API consumers and prevent over-posting attacks.
    /// </summary>
    public class InstructorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required")]
        [StringLength(100, ErrorMessage = "Department cannot exceed 100 characters")]
        public string Department { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Office hours cannot exceed 200 characters")]
        public string? OfficeHours { get; set; }
    }
}

