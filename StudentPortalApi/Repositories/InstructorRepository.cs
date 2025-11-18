using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.DTOs;
using StudentPortalApi.DTOs.Data;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    /// <summary>
    /// Repository implementation for Instructor data access operations.
    /// Uses async/await for all database operations to prevent thread blocking and improve scalability.
    /// </summary>
    public class InstructorRepository : IInstructorRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public InstructorRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstructorDTO>> GetAllInstructorsAsync()
        {
            var instructors = await _dbContext.Instructors.ToListAsync();
            return _mapper.Map<IEnumerable<InstructorDTO>>(instructors);
        }

        public async Task<InstructorDTO?> GetInstructorByIdAsync(int id)
        {
            var instructor = await _dbContext.Instructors.FindAsync(id);
            return instructor == null ? null : _mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<InstructorDTO> AddInstructorAsync(InstructorDTO instructorDto)
        {
            var instructor = _mapper.Map<Instructor>(instructorDto);
            _dbContext.Instructors.Add(instructor);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<InstructorDTO?> UpdateInstructorAsync(int id, InstructorDTO instructorDto)
        {
            var instructor = await _dbContext.Instructors.FindAsync(id);
            if (instructor == null) return null;

            _mapper.Map(instructorDto, instructor);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            var instructor = await _dbContext.Instructors.FindAsync(id);
            if (instructor == null) return false;

            _dbContext.Instructors.Remove(instructor);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

