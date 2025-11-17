using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentPortalApi.Enums;

namespace StudentPortalApi.DTOs
{
    /// <summary>
    /// Transport shape for exposing student information to clients without
    /// leaking EF tracking or internal domain concerns.
    /// </summary>
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string StudentId { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [StringLength(100)]
        public string? Major { get; set; }

        [Range(1, 10)]
        public int Year { get; set; }

        [Range(0.0, 4.0)]
        public double GPA { get; set; } // Computed from Grades

        public int TotalCredits { get; set; } // Computed from Grades

        [StringLength(300), Url]
        public string? ProfileImage { get; set; }

        [Required, StringLength(20), Phone]
        public string ContactNumber { get; set; } = string.Empty;

        public AddressDTO? Address { get; set; }

        // Include grades for GPA calculation
        public List<StudentGradeDTO>? Grades { get; set; }
    }

    /// <summary>
    /// Nested DTO that mirrors the Address entity for embedding within student payloads.
    /// </summary>
    public class AddressDTO
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required, StringLength(150)]
        public string Street { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string City { get; set; } = string.Empty;

        [StringLength(100)]
        public string? State { get; set; }

        [StringLength(20)]
        public string? ZipCode { get; set; }

        [Required, StringLength(100)]
        public string Country { get; set; } = string.Empty;
    }

    // DTO for course grades
    /// <summary>
    /// Lightweight DTO used to surface an individual course grade in student responses.
    /// </summary>
    public class StudentGradeDTO
    {
        [Required]
        public string LetterGrade { get; set; } = string.Empty; // mapped from enum

        [Required, Range(0, 10)]
        public int Credits { get; set; }

        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public string? Semester { get; set; }
    }
}
