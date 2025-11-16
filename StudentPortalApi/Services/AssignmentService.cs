using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<AssignmentDTO>> GetAllAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAssignmentsAsync();
        }

        public async Task<AssignmentDTO?> GetAssignmentByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _assignmentRepository.GetAssignmentByIdAsync(id);
        }

        public async Task<IEnumerable<AssignmentDTO>> GetAssignmentsByGradeIdAsync(int gradeId)
        {
            if (gradeId <= 0) return Enumerable.Empty<AssignmentDTO>();
            return await _assignmentRepository.GetAssignmentsByGradeIdAsync(gradeId);
        }

        public async Task<AssignmentDTO> CreateAssignmentAsync(AssignmentDTO assignmentDto)
        {
            return await _assignmentRepository.AddAssignmentAsync(assignmentDto);
        }

        public async Task<AssignmentDTO?> UpdateAssignmentAsync(int id, AssignmentDTO assignmentDto)
        {
            if (id <= 0) return null;
            return await _assignmentRepository.UpdateAssignmentAsync(id, assignmentDto);
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            if (id <= 0) return false;
            return await _assignmentRepository.DeleteAssignmentAsync(id);
        }
    }
}

