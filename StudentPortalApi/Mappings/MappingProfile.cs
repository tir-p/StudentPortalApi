using AutoMapper;
using StudentPortalApi.DTOs;
using StudentPortalApi.Models;
using StudentPortalApi.Enums;
using System;

namespace StudentPortalApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ========================
            // Student <-> StudentDTO
            // ========================
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.GPA, opt => opt.Ignore())          // Computed manually
                .ForMember(dest => dest.TotalCredits, opt => opt.Ignore()) // Computed manually
                .ReverseMap();

            // ========================
            // Address <-> AddressDTO
            // ========================
            CreateMap<Address, AddressDTO>().ReverseMap();

            // ========================
            // Course <-> CourseDTO
            // ========================
            CreateMap<Course, CourseDTO>().ReverseMap();

            // ========================
            // Instructor <-> InstructorDTO
            // ========================
            CreateMap<Instructor, InstructorDTO>().ReverseMap();

            // ========================
            // CourseSchedule <-> CourseScheduleDTO
            // ========================
            CreateMap<CourseSchedule, CourseScheduleDTO>().ReverseMap();

            // ========================
            // Attendance <-> AttendanceDTO
            // ========================
            CreateMap<Attendance, AttendanceDTO>().ReverseMap();

            // ========================
            // AttendanceRecord <-> AttendanceRecordDTO
            // ========================
            CreateMap<AttendanceRecord, AttendanceRecordDTO>().ReverseMap();

            // ========================
            // Assignment <-> AssignmentDTO
            // ========================
            CreateMap<Assignment, AssignmentDTO>().ReverseMap();

            // ========================
            // Grade <-> GradeDTO
            // ========================
            CreateMap<Grade, GradeDTO>()
                .ForMember(dest => dest.StudentName, opt => opt.Ignore()) // populated manually
                .ReverseMap();

            // ========================
            // Grade <-> StudentGradeDTO
            // ========================
            CreateMap<Grade, StudentGradeDTO>()
                .ForMember(dest => dest.LetterGrade, opt => opt.MapFrom(src => src.LetterGrade.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.LetterGrade, opt => opt.MapFrom(src => Enum.Parse<LetterGrade>(src.LetterGrade)));
        }
    }
}
