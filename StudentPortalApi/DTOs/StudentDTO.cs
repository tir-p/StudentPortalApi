using System;

namespace StudentPortalApi.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StudentId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string? Major { get; set; }
        public int Year { get; set; }
        public double GPA { get; set; }
        public string? ProfileImage { get; set; }
        public string ContactNumber { get; set; }

        // Optional: Flatten Address DTO if needed
        public AddressDTO? Address { get; set; }
    }

    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        // Don't include Student to avoid cycles
    }
}
