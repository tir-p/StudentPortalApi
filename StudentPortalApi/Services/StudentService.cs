using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Service implementation for Student business logic.
    /// This layer handles business rules, validation, and orchestrates repository calls.
    /// Benefits: Separation of concerns, testability, and centralized business logic.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task<StudentDTO> CreateStudentAsync(StudentDTO studentDto)
        {
            // Business logic validation can be added here
            // For example: Check if email already exists, validate GPA range, etc.

            return await _studentRepository.AddStudentAsync(studentDto);
        }

        public async Task<StudentDTO?> UpdateStudentAsync(int id, StudentDTO studentDto)
        {
            if (id <= 0)
                return null;

            // Business logic validation can be added here
            return await _studentRepository.UpdateStudentAsync(id, studentDto);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _studentRepository.DeleteStudentAsync(id);
        }
    }
}

