using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Service implementation for Student business logic.
    /// Handles GPA calculation, total credits, and orchestrates repository calls.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Get all students and calculate GPA & total credits for each
        /// </summary>
        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();

            foreach (var student in students)
            {
                CalculateStudentGPA(student);
            }

            return students;
        }

        /// <summary>
        /// Get a student by ID and calculate GPA & total credits
        /// </summary>
        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            if (id <= 0) return null;

            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student != null)
            {
                CalculateStudentGPA(student);
            }

            return student;
        }

        /// <summary>
        /// Create a new student and calculate GPA & total credits if grades exist
        /// </summary>
        public async Task<StudentDTO> CreateStudentAsync(StudentDTO studentDto)
        {
            CalculateStudentGPA(studentDto);
            return await _studentRepository.AddStudentAsync(studentDto);
        }

        /// <summary>
        /// Update existing student and recalculate GPA & total credits if grades exist
        /// </summary>
        public async Task<StudentDTO?> UpdateStudentAsync(int id, StudentDTO studentDto)
        {
            if (id <= 0) return null;

            CalculateStudentGPA(studentDto);
            return await _studentRepository.UpdateStudentAsync(id, studentDto);
        }

        /// <summary>
        /// Delete a student by ID
        /// </summary>
        public async Task<bool> DeleteStudentAsync(int id)
        {
            if (id <= 0) return false;

            return await _studentRepository.DeleteStudentAsync(id);
        }

        /// <summary>
        /// Utility method to calculate GPA & total credits for a student
        /// </summary>
        private void CalculateStudentGPA(StudentDTO student)
        {
            if (student.Grades != null && student.Grades.Count > 0)
            {
                student.GPA = GradeUtil.CalculateGPA(student.Grades);
                student.TotalCredits = GradeUtil.CalculateTotalCredits(student.Grades);
            }
            else
            {
                student.GPA = 0;
                student.TotalCredits = 0;
            }
        }
    }
}
