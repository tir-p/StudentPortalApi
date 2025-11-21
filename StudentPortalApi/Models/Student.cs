using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentPortalApi.Models;

/// <summary>
/// Represents the aggregate root for a student's academic profile, including
/// demographic details, contact information, and navigation properties to related
/// domain entities such as <see cref="Address"/> and <see cref="Grade"/>.
/// </summary>
public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }   // Identity column

    [Required]
    [MaxLength(50)]
    [Column("FirstName")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("LastName")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [Column("Email")]
    public string Email { get; set; }

    // Student ID issued by university
    [Required]
    [MaxLength(20)]
    [Column("StudentId")]
    public string StudentId { get; set; }

    [Column("DateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [Column("EnrollmentDate")]
    public DateTime EnrollmentDate { get; set; }

    [MaxLength(100)]
    [Column("Major")]
    public string? Major { get; set; }

    [Column("Year")]
    public int Year { get; set; }

    [Column("GPA")]
    public double GPA { get; set; }

    [MaxLength(300)]
    [Column("ProfileImage")]
    public string? ProfileImage { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("ContactNumber")]
    public string? ContactNumber { get; set; }

    // Navigation properties
    public Address? Address { get; set; }  // one-to-one, FK on Address
    public ICollection<Grade> Grades { get; set; } = new List<Grade>(); // one-to-many
}
