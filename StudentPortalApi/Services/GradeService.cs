using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Service implementation for Grade business logic.
    /// This layer handles business rules, validation, and orchestrates repository calls.
    /// </summary>
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<GradeDTO>> GetAllGradesAsync()
        {
            return await _gradeRepository.GetAllGradesAsync();
        }

        public async Task<GradeDTO?> GetGradeByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _gradeRepository.GetGradeByIdAsync(id);
        }

        public async Task<IEnumerable<GradeDTO>> GetGradesByStudentIdAsync(int studentId)
        {
            if (studentId <= 0)
                return Enumerable.Empty<GradeDTO>();

            return await _gradeRepository.GetGradesByStudentIdAsync(studentId);
        }

        public async Task<IEnumerable<GradeDTO>> GetGradesByCourseIdAsync(int courseId)
        {
            if (courseId <= 0)
                return Enumerable.Empty<GradeDTO>();

            return await _gradeRepository.GetGradesByCourseIdAsync(courseId);
        }

        public async Task<GradeDTO> CreateGradeAsync(GradeDTO gradeDto)
        {
            // Business logic validation can be added here
            // For example: Check if student and course exist, validate score ranges, etc.
            
            return await _gradeRepository.AddGradeAsync(gradeDto);
        }

        public async Task<GradeDTO?> UpdateGradeAsync(int id, GradeDTO gradeDto)
        {
            if (id <= 0)
                return null;

            // Business logic validation can be added here
            return await _gradeRepository.UpdateGradeAsync(id, gradeDto);
        }

        public async Task<bool> DeleteGradeAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _gradeRepository.DeleteGradeAsync(id);
        }
    }
}

