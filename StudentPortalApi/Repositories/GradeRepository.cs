using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.Data;
using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GradeRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GradeDTO>> GetAllGradesAsync()
        {
            var grades = await _dbContext.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .Include(g => g.Assignments)
                .ToListAsync();

            var gradeDtos = _mapper.Map<IEnumerable<GradeDTO>>(grades);

            // Set StudentName in one line
            foreach (var dto in gradeDtos)
            {
                dto.StudentName = $"{grades.First(g => g.Id == dto.Id).Student?.FirstName} {grades.First(g => g.Id == dto.Id).Student?.LastName}".Trim();
            }

            return gradeDtos;
        }

        public async Task<GradeDTO?> GetGradeByIdAsync(int id)
        {
            var grade = await _dbContext.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .Include(g => g.Assignments)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (grade == null) return null;

            var gradeDto = _mapper.Map<GradeDTO>(grade);
            gradeDto.StudentName = $"{grade.Student?.FirstName} {grade.Student?.LastName}".Trim();
            return gradeDto;
        }

        public async Task<IEnumerable<GradeDTO>> GetGradesByStudentIdAsync(int studentId)
        {
            var grades = await _dbContext.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .Include(g => g.Assignments)
                .Where(g => g.StudentId == studentId)
                .ToListAsync();

            var gradeDtos = _mapper.Map<IEnumerable<GradeDTO>>(grades);

            foreach (var dto in gradeDtos)
            {
                dto.StudentName = $"{grades.First(g => g.Id == dto.Id).Student?.FirstName} {grades.First(g => g.Id == dto.Id).Student?.LastName}".Trim();
            }

            return gradeDtos;
        }

        public async Task<IEnumerable<GradeDTO>> GetGradesByCourseIdAsync(int courseId)
        {
            var grades = await _dbContext.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .Include(g => g.Assignments)
                .Where(g => g.CourseId == courseId)
                .ToListAsync();

            var gradeDtos = _mapper.Map<IEnumerable<GradeDTO>>(grades);

            foreach (var dto in gradeDtos)
            {
                dto.StudentName = $"{grades.First(g => g.Id == dto.Id).Student?.FirstName} {grades.First(g => g.Id == dto.Id).Student?.LastName}".Trim();
            }

            return gradeDtos;
        }

        public async Task<GradeDTO> AddGradeAsync(GradeDTO gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            _dbContext.Grades.Add(grade);
            await _dbContext.SaveChangesAsync();

            await _dbContext.Entry(grade).Reference(g => g.Student).LoadAsync();
            await _dbContext.Entry(grade).Reference(g => g.Course).LoadAsync();
            await _dbContext.Entry(grade).Collection(g => g.Assignments).LoadAsync();

            var result = _mapper.Map<GradeDTO>(grade);
            result.StudentName = $"{grade.Student?.FirstName} {grade.Student?.LastName}".Trim();
            return result;
        }

        public async Task<GradeDTO?> UpdateGradeAsync(int id, GradeDTO gradeDto)
        {
            var grade = await _dbContext.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .Include(g => g.Assignments)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (grade == null) return null;

            _mapper.Map(gradeDto, grade);
            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<GradeDTO>(grade);
            result.StudentName = $"{grade.Student?.FirstName} {grade.Student?.LastName}".Trim();
            return result;
        }

        public async Task<bool> DeleteGradeAsync(int id)
        {
            var grade = await _dbContext.Grades.FindAsync(id);
            if (grade == null) return false;

            _dbContext.Grades.Remove(grade);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
