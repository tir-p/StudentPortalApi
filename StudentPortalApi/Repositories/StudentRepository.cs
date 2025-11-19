using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.DTOs;
using StudentPortalApi.Extensions;
using StudentPortalApi.Interfaces;
using StudentPortal.Api.Data;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    /// <summary>
    /// Repository implementation for Student data access operations.
    /// This layer handles all database interactions using Entity Framework.
    /// Benefits: Separation of data access from business logic, testability, and reusability.
    /// 
    /// Uses async/await for all database operations to:
    /// 1. Prevent thread blocking during I/O operations
    /// 2. Improve scalability by allowing threads to handle other requests
    /// 3. Better resource utilization
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public StudentRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            // Using extension method to reduce code duplication (DRY principle)
            var students = await _dbContext.Students
                .IncludeRelatedEntities()
                .ToListAsync();

            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            // Using extension method to reduce code duplication (DRY principle)
            var student = await _dbContext.Students
                .IncludeRelatedEntities()
                .FirstOrDefaultAsync(s => s.Id == id);

            return student == null ? null : _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> AddStudentAsync(StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO?> UpdateStudentAsync(int id, StudentDTO studentDto)
        {
            // Load student including related Address
            var student = await _dbContext.Students
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return null;

            // Update scalar properties
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.Email = studentDto.Email;
            student.StudentId = studentDto.StudentId;
            student.DateOfBirth = studentDto.DateOfBirth;
            student.EnrollmentDate = studentDto.EnrollmentDate;
            student.Major = studentDto.Major;
            student.Year = studentDto.Year;
            student.GPA = studentDto.GPA;
            student.ProfileImage = studentDto.ProfileImage;
            student.ContactNumber = studentDto.ContactNumber;

            // Update address if it exists
            if (student.Address != null && studentDto.Address != null)
            {
                student.Address.Street = studentDto.Address.Street;
                student.Address.City = studentDto.Address.City;
                student.Address.State = studentDto.Address.State;
                student.Address.ZipCode = studentDto.Address.ZipCode;
                student.Address.Country = studentDto.Address.Country;
            }
            else if (student.Address == null && studentDto.Address != null)
            {
                // If student has no address yet, create one
                student.Address = new Address
                {
                    Street = studentDto.Address.Street,
                    City = studentDto.Address.City,
                    State = studentDto.Address.State,
                    ZipCode = studentDto.Address.ZipCode,
                    Country = studentDto.Address.Country,
                    StudentId = student.Id
                };
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<StudentDTO>(student);
        }


        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null) return false;

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

