using AutoMapper;
using StudentPortalApi.DTOs;
using StudentPortalApi.Models;

namespace StudentPortalApi.Mappings
{
    /// <summary>
    /// AutoMapper profile for mapping between Domain Models and DTOs.
    /// 
    /// Why use DTOs and Mapping?
    /// 1. Security: Prevents over-posting attacks by controlling exposed properties
    /// 2. Performance: Exclude unnecessary navigation properties from API responses
    /// 3. Decoupling: API contracts are independent of database schema
    /// 4. Versioning: Can version APIs without changing domain models
    /// 5. Validation: DTOs can have different validation rules than domain models
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Student <-> StudentDTO
            // ReverseMap() creates bidirectional mapping
            CreateMap<Student, StudentDTO>()
                .ReverseMap();

            // Map Address <-> AddressDTO
            CreateMap<Address, AddressDTO>()
                .ReverseMap();

            // Map Course <-> CourseDTO
            CreateMap<Course, CourseDTO>()
                .ReverseMap();

            // Map Grade <-> GradeDTO
            CreateMap<Grade, GradeDTO>()
                .ReverseMap();

            // Map Instructor <-> InstructorDTO
            CreateMap<Instructor, InstructorDTO>()
                .ReverseMap();

            // Map CourseSchedule <-> CourseScheduleDTO
            CreateMap<CourseSchedule, CourseScheduleDTO>()
                .ReverseMap();

            // Map Attendance <-> AttendanceDTO
            CreateMap<Attendance, AttendanceDTO>()
                .ReverseMap();

            // Map AttendanceRecord <-> AttendanceRecordDTO
            CreateMap<AttendanceRecord, AttendanceRecordDTO>()
                .ReverseMap();

            // Map Assignment <-> AssignmentDTO
            CreateMap<Assignment, AssignmentDTO>()
                .ReverseMap();
        }
    }
}
