using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.DTOs;
using StudentPortalApi.DTOs.Data;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    /// <summary>
    /// EF Core-backed repository for CRUD operations on Assignment entities.
    /// </summary>
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public AssignmentRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssignmentDTO>> GetAllAssignmentsAsync()
        {
            var assignments = await _dbContext.Assignments
                .Include(a => a.Grade)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AssignmentDTO>>(assignments);
        }

        public async Task<AssignmentDTO?> GetAssignmentByIdAsync(int id)
        {
            var assignment = await _dbContext.Assignments
                .Include(a => a.Grade)
                .FirstOrDefaultAsync(a => a.Id == id);

            return assignment == null ? null : _mapper.Map<AssignmentDTO>(assignment);
        }

        public async Task<IEnumerable<AssignmentDTO>> GetAssignmentsByGradeIdAsync(int gradeId)
        {
            var assignments = await _dbContext.Assignments
                .Include(a => a.Grade)
                .Where(a => a.GradeId == gradeId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AssignmentDTO>>(assignments);
        }

        public async Task<AssignmentDTO> AddAssignmentAsync(AssignmentDTO assignmentDto)
        {
            var assignment = _mapper.Map<Assignment>(assignmentDto);
            _dbContext.Assignments.Add(assignment);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AssignmentDTO>(assignment);
        }

        public async Task<AssignmentDTO?> UpdateAssignmentAsync(int id, AssignmentDTO assignmentDto)
        {
            var assignment = await _dbContext.Assignments.FindAsync(id);
            if (assignment == null) return null;

            _mapper.Map(assignmentDto, assignment);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<AssignmentDTO>(assignment);
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            var assignment = await _dbContext.Assignments.FindAsync(id);
            if (assignment == null) return false;

            _dbContext.Assignments.Remove(assignment);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

