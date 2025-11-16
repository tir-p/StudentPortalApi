using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.Data;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
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
            var students = await _dbContext.Students
                .Include(s => s.Address)
                .Include(s => s.Grades)
                .ToListAsync();

            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            var student = await _dbContext.Students
                .Include(s => s.Address)
                .Include(s => s.Grades)
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
            var student = await _dbContext.Students
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return null;

            _mapper.Map(studentDto, student);
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
