using Microsoft.EntityFrameworkCore;
using StudentPortalApi.Enums;
using StudentPortalApi.Models;
using System;

namespace StudentPortalApi.Data
{
    public class StudentPortalDbContext : DbContext
    {
        public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSchedule> CourseSchedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ======================
            // Relationships
            // ======================
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(a => a.StudentId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany()
                .HasForeignKey(c => c.InstructorId);

            modelBuilder.Entity<CourseSchedule>()
                .HasOne<Course>()
                .WithMany(c => c.Schedule)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<AttendanceRecord>()
                .HasOne<Attendance>()
                .WithMany(a => a.Records)
                .HasForeignKey(ar => ar.AttendanceId);

            modelBuilder.Entity<Grade>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne<Course>()
                .WithMany()
                .HasForeignKey(g => g.CourseId);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Grade)
                .WithMany(g => g.Assignments)
                .HasForeignKey(a => a.GradeId);

            // ======================
            // Seeding
            // ======================

            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Tirthesh",
                    LastName = "Parbutee",
                    Email = "tirthesh.parbutee@university.mu",
                    StudentId = "CS202101",
                    DateOfBirth = new DateTime(2003, 10, 22),
                    EnrollmentDate = new DateTime(2023, 06, 01),
                    Major = "Computer Science",
                    Year = 3,
                    GPA = 3.75,
                    ContactNumber = "+230-5123-4567",
                    ProfileImage = "/assets/images/default-avatar.png"
                }
            );

            // Addresses
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    StudentId = 1,
                    Street = "123 University Street",
                    City = "Reduit",
                    State = "Moka",
                    ZipCode = "80837",
                    Country = "Mauritius"
                }
            );

            // Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Dr. J Seetohul", Email = "j.seetohul@university.mu", Department = "Computer Science", OfficeHours = "Mon/Wed 2-4 PM" },
                new Instructor { Id = 2, Name = "Prof. Jesus", Email = "prof.jesus@university.mu", Department = "Computer Science", OfficeHours = "Tue/Thu 1-3 PM" },
                new Instructor { Id = 3, Name = "Dr. Jean Melon", Email = "jean.melon@university.mu", Department = "Computer Science", OfficeHours = "Wed/Fri 10-12 PM" },
                new Instructor { Id = 4, Name = "Mr Gavin Sathan", Email = "g.sathan@university.mu", Department = "Computer Science", OfficeHours = "Mon/Thu 3-5 PM" }
            );

            // Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Code = "CSE-4101", Name = "Advanced Software Engineering", Description = "Design patterns, architecture, and best practices", Credits = 3, Semester = "fall-2025", InstructorId = 1, EnrolledStudents = 45, MaxCapacity = 50, Status = CourseStatus.Active },
                new Course { Id = 2, Code = "CSE-4102", Name = "Machine Learning", Description = "Introduction to ML algorithms and applications", Credits = 4, Semester = "fall-2025", InstructorId = 2, EnrolledStudents = 38, MaxCapacity = 40, Status = CourseStatus.Active },
                new Course { Id = 3, Code = "CSE-4103", Name = "Cloud Computing", Description = "Cloud infrastructure, services, and deployment", Credits = 3, Semester = "fall-2025", InstructorId = 3, EnrolledStudents = 42, MaxCapacity = 45, Status = CourseStatus.Active },
                new Course { Id = 4, Code = "CSE-4104", Name = "Operating Systems", Description = "OS concepts, process management, memory management, and file systems", Credits = 3, Semester = "fall-2025", InstructorId = 4, EnrolledStudents = 35, MaxCapacity = 40, Status = CourseStatus.Active }
            );

            // CourseSchedules
            modelBuilder.Entity<CourseSchedule>().HasData(
                new CourseSchedule { Id = 1, CourseId = 1, Day = "Monday", StartTime = "10:00", EndTime = "11:30", Location = "Room 301" },
                new CourseSchedule { Id = 2, CourseId = 1, Day = "Wednesday", StartTime = "10:00", EndTime = "11:30", Location = "Room 301" },
                new CourseSchedule { Id = 3, CourseId = 2, Day = "Tuesday", StartTime = "14:00", EndTime = "15:30", Location = "Lab 205" },
                new CourseSchedule { Id = 4, CourseId = 2, Day = "Thursday", StartTime = "14:00", EndTime = "15:30", Location = "Lab 205" }
            );

            // Attendances
            modelBuilder.Entity<Attendance>().HasData(
                new Attendance { Id = 1, StudentId = 1, CourseId = 1, CourseName = "Advanced Software Engineering", CourseCode = "CSE-4101", TotalClasses = 20, AttendedClasses = 19, AttendancePercentage = 95, Status = AttendanceStatus.Good }
            );

            // AttendanceRecords
            modelBuilder.Entity<AttendanceRecord>().HasData(
                new AttendanceRecord { Id = 1, AttendanceId = 1, Date = new DateTime(2025, 09, 02), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture, Remarks = "" },
                new AttendanceRecord { Id = 2, AttendanceId = 1, Date = new DateTime(2025, 09, 04), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture }
            );

            // Grades
            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, StudentId = 1, CourseId = 1, CourseName = "Advanced Software Engineering", CourseCode = "CSE-4101", Semester = "fall-2025", TotalScore = 90, LetterGrade = LetterGrade.A, GradePoints = 4.0, Credits = 3 }
            );

            // Assignments
            modelBuilder.Entity<Assignment>().HasData(
                new Assignment { Id = 1, GradeId = 1, Name = "Design Patterns Assignment", MaxScore = 100, EarnedScore = 92, Weight = 20, DueDate = new DateTime(2025, 10, 15), SubmittedDate = new DateTime(2025, 10, 14), Status = AssignmentStatus.Graded, Feedback = "Excellent work on implementing the Factory pattern!" }
            );
        }
    }
}
