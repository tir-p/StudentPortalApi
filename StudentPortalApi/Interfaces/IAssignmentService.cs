using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentDTO>> GetAllAssignmentsAsync();
        Task<AssignmentDTO?> GetAssignmentByIdAsync(int id);
        Task<IEnumerable<AssignmentDTO>> GetAssignmentsByGradeIdAsync(int gradeId);
        Task<AssignmentDTO> CreateAssignmentAsync(AssignmentDTO assignmentDto);
        Task<AssignmentDTO?> UpdateAssignmentAsync(int id, AssignmentDTO assignmentDto);
        Task<bool> DeleteAssignmentAsync(int id);
    }
}

