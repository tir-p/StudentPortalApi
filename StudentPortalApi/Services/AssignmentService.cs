using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Orchestrates assignment workflows while delegating persistence to the repository layer.
    /// </summary>
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        /// <summary>
        /// Returns every assignment in the system.
        /// </summary>
        public async Task<IEnumerable<AssignmentDTO>> GetAllAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAssignmentsAsync();
        }

        /// <summary>
        /// Retrieves a single assignment by ID.
        /// </summary>
        public async Task<AssignmentDTO?> GetAssignmentByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _assignmentRepository.GetAssignmentByIdAsync(id);
        }

        /// <summary>
        /// Lists assignments tied to a grade aggregate.
        /// </summary>
        public async Task<IEnumerable<AssignmentDTO>> GetAssignmentsByGradeIdAsync(int gradeId)
        {
            if (gradeId <= 0) return Enumerable.Empty<AssignmentDTO>();
            return await _assignmentRepository.GetAssignmentsByGradeIdAsync(gradeId);
        }

        /// <summary>
        /// Creates a new assignment entity.
        /// </summary>
        public async Task<AssignmentDTO> CreateAssignmentAsync(AssignmentDTO assignmentDto)
        {
            return await _assignmentRepository.AddAssignmentAsync(assignmentDto);
        }

        /// <summary>
        /// Updates an assignment when a valid id is provided.
        /// </summary>
        public async Task<AssignmentDTO?> UpdateAssignmentAsync(int id, AssignmentDTO assignmentDto)
        {
            if (id <= 0) return null;
            return await _assignmentRepository.UpdateAssignmentAsync(id, assignmentDto);
        }

        /// <summary>
        /// Deletes an assignment by ID.
        /// </summary>
        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            if (id <= 0) return false;
            return await _assignmentRepository.DeleteAssignmentAsync(id);
        }
    }
}

