using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Data Transfer Object for Student.
    /// DTOs are used to:
    /// 1. Control what data is exposed to the API consumers
    /// 2. Prevent over-posting attacks
    /// 3. Decouple API contracts from internal domain models
    /// 4. Optimize data transfer (exclude unnecessary navigation properties)
    /// 5. Version APIs independently from database schema
    /// </summary>
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student ID is required")]
        [StringLength(20, ErrorMessage = "Student ID cannot exceed 20 characters")]
        public string StudentId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [StringLength(100, ErrorMessage = "Major cannot exceed 100 characters")]
        public string? Major { get; set; }

        [Range(1, 10, ErrorMessage = "Year must be between 1 and 10")]
        public int Year { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public double GPA { get; set; }

        [StringLength(300, ErrorMessage = "Profile image path cannot exceed 300 characters")]
        [Url(ErrorMessage = "Profile image must be a valid URL")]
        public string? ProfileImage { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [StringLength(20, ErrorMessage = "Contact number cannot exceed 20 characters")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string ContactNumber { get; set; } = string.Empty;

        // Optional: Flatten Address DTO if needed
        public AddressDTO? Address { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Address.
    /// Separated from Student to allow independent updates and better structure.
    /// </summary>
    public class AddressDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student ID is required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(150, ErrorMessage = "Street cannot exceed 150 characters")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string City { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "State cannot exceed 100 characters")]
        public string? State { get; set; }

        [StringLength(20, ErrorMessage = "Zip code cannot exceed 20 characters")]
        public string? ZipCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters")]
        public string Country { get; set; } = string.Empty;
    }
}
