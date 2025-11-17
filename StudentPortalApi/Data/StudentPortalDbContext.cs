using Microsoft.EntityFrameworkCore;
using StudentPortalApi.Enums;
using StudentPortalApi.Models;
using System;

namespace StudentPortalApi.Data
{
    /// <summary>
    /// Entity Framework Core context that wires up the Student Portal domain model,
    /// configures relationships, and seeds demo data for development/testing scenarios.
    /// </summary>
    public class StudentPortalDbContext : DbContext
    {
        public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options)
            : base(options)
        {
        }

        public StudentPortalDbContext() : base()
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

        /// <summary>
        /// Configures entity relationships, cascade rules, and seed data.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // ======================
            // Relationships
            // ======================

            // Student -> Address (1:1)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Course -> Instructor (Many:1)
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany()
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            // CourseSchedule -> Course (Many:1)
            modelBuilder.Entity<CourseSchedule>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.Schedule)
                .HasForeignKey(cs => cs.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // AttendanceRecord -> Attendance (Many:1)
            modelBuilder.Entity<AttendanceRecord>()
                .HasOne(ar => ar.Attendance)
                .WithMany(a => a.Records)
                .HasForeignKey(ar => ar.AttendanceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Grade -> Student (Many:1)
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Grade -> Course (Many:1)
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Assignment -> Grade (Many:1)
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Grade)
                .WithMany(g => g.Assignments)
                .HasForeignKey(a => a.GradeId)
                .OnDelete(DeleteBehavior.Cascade);

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
                new Instructor { Id = 4, Name = "Mr G Sathan", Email = "g.sathan@university.mu", Department = "Computer Science", OfficeHours = "Mon/Thu 3-5 PM" }
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

            // ======================
            // Attendances
            // ======================
            modelBuilder.Entity<Attendance>().HasData(
                new Attendance { Id = 1, StudentId = 1, CourseId = 1, CourseName = "Advanced Software Engineering", CourseCode = "CSE-4101", TotalClasses = 20, AttendedClasses = 19, AttendancePercentage = 95, Status = AttendanceStatus.Good },
                new Attendance { Id = 2, StudentId = 1, CourseId = 2, CourseName = "Machine Learning", CourseCode = "CSE-4102", TotalClasses = 18, AttendedClasses = 13, AttendancePercentage = 72.2, Status = AttendanceStatus.Warning },
                new Attendance { Id = 3, StudentId = 1, CourseId = 3, CourseName = "Cloud Computing", CourseCode = "CSE-4103", TotalClasses = 16, AttendedClasses = 16, AttendancePercentage = 100, Status = AttendanceStatus.Good },
                new Attendance { Id = 4, StudentId = 1, CourseId = 4, CourseName = "Operating Systems", CourseCode = "CSE-4104", TotalClasses = 20, AttendedClasses = 12, AttendancePercentage = 60, Status = AttendanceStatus.Critical }
            );

            // ======================
            // AttendanceRecords
            // ======================
            modelBuilder.Entity<AttendanceRecord>().HasData(
                // Attendance 1 (20 records)
                new AttendanceRecord { Id = 1, AttendanceId = 1, Date = new DateTime(2025, 09, 02), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture, Remarks = "" },
                new AttendanceRecord { Id = 2, AttendanceId = 1, Date = new DateTime(2025, 09, 04), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 3, AttendanceId = 1, Date = new DateTime(2025, 09, 09), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 4, AttendanceId = 1, Date = new DateTime(2025, 09, 11), Status = AttendanceRecordStatus.Late, ClassType = ClassType.Lecture, Remarks = "Arrived 10 minutes late" },
                new AttendanceRecord { Id = 5, AttendanceId = 1, Date = new DateTime(2025, 09, 16), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 6, AttendanceId = 1, Date = new DateTime(2025, 09, 18), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture, Remarks = "Medical leave" },
                new AttendanceRecord { Id = 7, AttendanceId = 1, Date = new DateTime(2025, 09, 23), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 8, AttendanceId = 1, Date = new DateTime(2025, 09, 25), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 9, AttendanceId = 1, Date = new DateTime(2025, 09, 30), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 10, AttendanceId = 1, Date = new DateTime(2025, 10, 02), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 11, AttendanceId = 1, Date = new DateTime(2025, 10, 07), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 12, AttendanceId = 1, Date = new DateTime(2025, 10, 09), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 13, AttendanceId = 1, Date = new DateTime(2025, 10, 14), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 14, AttendanceId = 1, Date = new DateTime(2025, 10, 16), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 15, AttendanceId = 1, Date = new DateTime(2025, 10, 21), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 16, AttendanceId = 1, Date = new DateTime(2025, 10, 23), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 17, AttendanceId = 1, Date = new DateTime(2025, 10, 28), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 18, AttendanceId = 1, Date = new DateTime(2025, 10, 30), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 19, AttendanceId = 1, Date = new DateTime(2025, 11, 04), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 20, AttendanceId = 1, Date = new DateTime(2025, 11, 06), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },

                // Attendance 2 (18 records)
                new AttendanceRecord { Id = 21, AttendanceId = 2, Date = new DateTime(2025, 09, 03), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 22, AttendanceId = 2, Date = new DateTime(2025, 09, 05), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 23, AttendanceId = 2, Date = new DateTime(2025, 09, 10), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lab, Remarks = "Personal emergency" },
                new AttendanceRecord { Id = 24, AttendanceId = 2, Date = new DateTime(2025, 09, 12), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 25, AttendanceId = 2, Date = new DateTime(2025, 09, 17), Status = AttendanceRecordStatus.Late, ClassType = ClassType.Lab, Remarks = "Arrived 15 minutes late" },
                new AttendanceRecord { Id = 26, AttendanceId = 2, Date = new DateTime(2025, 09, 19), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 27, AttendanceId = 2, Date = new DateTime(2025, 09, 24), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 28, AttendanceId = 2, Date = new DateTime(2025, 09, 26), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 29, AttendanceId = 2, Date = new DateTime(2025, 10, 01), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 30, AttendanceId = 2, Date = new DateTime(2025, 10, 03), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 31, AttendanceId = 2, Date = new DateTime(2025, 10, 08), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 32, AttendanceId = 2, Date = new DateTime(2025, 10, 10), Status = AttendanceRecordStatus.Excused, ClassType = ClassType.Lab, Remarks = "Official university event" },
                new AttendanceRecord { Id = 33, AttendanceId = 2, Date = new DateTime(2025, 10, 15), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 34, AttendanceId = 2, Date = new DateTime(2025, 10, 17), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 35, AttendanceId = 2, Date = new DateTime(2025, 10, 22), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 36, AttendanceId = 2, Date = new DateTime(2025, 10, 24), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 37, AttendanceId = 2, Date = new DateTime(2025, 10, 29), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },
                new AttendanceRecord { Id = 38, AttendanceId = 2, Date = new DateTime(2025, 10, 31), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lab },

                // Attendance 3 (16 records)
                new AttendanceRecord { Id = 39, AttendanceId = 3, Date = new DateTime(2025, 09, 04), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 40, AttendanceId = 3, Date = new DateTime(2025, 09, 06), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 41, AttendanceId = 3, Date = new DateTime(2025, 09, 11), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 42, AttendanceId = 3, Date = new DateTime(2025, 09, 13), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 43, AttendanceId = 3, Date = new DateTime(2025, 09, 18), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 44, AttendanceId = 3, Date = new DateTime(2025, 09, 20), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 45, AttendanceId = 3, Date = new DateTime(2025, 09, 25), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 46, AttendanceId = 3, Date = new DateTime(2025, 09, 27), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 47, AttendanceId = 3, Date = new DateTime(2025, 10, 02), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 48, AttendanceId = 3, Date = new DateTime(2025, 10, 04), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 49, AttendanceId = 3, Date = new DateTime(2025, 10, 09), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 50, AttendanceId = 3, Date = new DateTime(2025, 10, 11), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 51, AttendanceId = 3, Date = new DateTime(2025, 10, 16), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 52, AttendanceId = 3, Date = new DateTime(2025, 10, 18), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 53, AttendanceId = 3, Date = new DateTime(2025, 10, 23), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 54, AttendanceId = 3, Date = new DateTime(2025, 10, 25), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },

                // Attendance 4 (20 records)
                new AttendanceRecord { Id = 55, AttendanceId = 4, Date = new DateTime(2025, 09, 02), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 56, AttendanceId = 4, Date = new DateTime(2025, 09, 05), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture, Remarks = "Missed class" },
                new AttendanceRecord { Id = 57, AttendanceId = 4, Date = new DateTime(2025, 09, 09), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 58, AttendanceId = 4, Date = new DateTime(2025, 09, 12), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 59, AttendanceId = 4, Date = new DateTime(2025, 09, 16), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 60, AttendanceId = 4, Date = new DateTime(2025, 09, 19), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture, Remarks = "Medical appointment" },
                new AttendanceRecord { Id = 61, AttendanceId = 4, Date = new DateTime(2025, 09, 23), Status = AttendanceRecordStatus.Late, ClassType = ClassType.Lecture, Remarks = "Arrived 20 minutes late" },
                new AttendanceRecord { Id = 62, AttendanceId = 4, Date = new DateTime(2025, 09, 26), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 63, AttendanceId = 4, Date = new DateTime(2025, 09, 30), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 64, AttendanceId = 4, Date = new DateTime(2025, 10, 03), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 65, AttendanceId = 4, Date = new DateTime(2025, 10, 07), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 66, AttendanceId = 4, Date = new DateTime(2025, 10, 10), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 67, AttendanceId = 4, Date = new DateTime(2025, 10, 14), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 68, AttendanceId = 4, Date = new DateTime(2025, 10, 17), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 69, AttendanceId = 4, Date = new DateTime(2025, 10, 21), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 70, AttendanceId = 4, Date = new DateTime(2025, 10, 24), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 71, AttendanceId = 4, Date = new DateTime(2025, 10, 28), Status = AttendanceRecordStatus.Absent, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 72, AttendanceId = 4, Date = new DateTime(2025, 10, 31), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 73, AttendanceId = 4, Date = new DateTime(2025, 11, 04), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture },
                new AttendanceRecord { Id = 74, AttendanceId = 4, Date = new DateTime(2025, 11, 07), Status = AttendanceRecordStatus.Present, ClassType = ClassType.Lecture }
            );


            // Grades
            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, StudentId = 1, CourseId = 1, CourseName = "Advanced Software Engineering", CourseCode = "CSE-4101", Semester = "fall-2025", TotalScore = 90, LetterGrade = LetterGrade.A, GradePoints = 4.0, Credits = 3 },
                new Grade { Id = 2, StudentId = 1, CourseId = 2, CourseName = "Machine Learning", CourseCode = "CSE-4102", Semester = "fall-2025", TotalScore = 85, LetterGrade = LetterGrade.B, GradePoints = 3.0, Credits = 4 },
                new Grade { Id = 3, StudentId = 1, CourseId = 1, CourseName = "Advanced Software Engineering", CourseCode = "CSE-4101", Semester = "fall-2025", TotalScore = 88, LetterGrade = LetterGrade.B, GradePoints = 3.5, Credits = 3 },
                new Grade { Id = 4, StudentId = 1, CourseId = 3, CourseName = "Cloud Computing", CourseCode = "CSE-4103", Semester = "fall-2025", TotalScore = 92, LetterGrade = LetterGrade.A, GradePoints = 4.0, Credits = 3 },
                new Grade { Id = 5, StudentId = 1, CourseId = 2, CourseName = "Machine Learning", CourseCode = "CSE-4102", Semester = "fall-2025", TotalScore = 95, LetterGrade = LetterGrade.A, GradePoints = 4.0, Credits = 4 },
                new Grade { Id = 6, StudentId = 1, CourseId = 4, CourseName = "Operating Systems", CourseCode = "CSE-4104", Semester = "fall-2025", TotalScore = 78, LetterGrade = LetterGrade.C, GradePoints = 2.0, Credits = 3 }
            );

            // Assignments
            modelBuilder.Entity<Assignment>().HasData(
                new Assignment { Id = 1, GradeId = 1, Name = "Design Patterns Assignment", MaxScore = 100, EarnedScore = 92, Weight = 20, DueDate = new DateTime(2025, 10, 15), SubmittedDate = new DateTime(2025, 10, 14), Status = AssignmentStatus.Graded, Feedback = "Excellent work!" },
                new Assignment { Id = 2, GradeId = 2, Name = "ML Project", MaxScore = 100, EarnedScore = 85, Weight = 30, DueDate = new DateTime(2025, 11, 10), SubmittedDate = new DateTime(2025, 11, 09), Status = AssignmentStatus.Graded, Feedback = "Good implementation" },
                new Assignment { Id = 3, GradeId = 3, Name = "Software Engineering Assignment", MaxScore = 100, EarnedScore = 88, Weight = 25, DueDate = new DateTime(2025, 10, 20), SubmittedDate = new DateTime(2025, 10, 19), Status = AssignmentStatus.Graded, Feedback = "Well done" },
                new Assignment { Id = 4, GradeId = 4, Name = "Cloud Deployment Lab", MaxScore = 100, EarnedScore = 92, Weight = 20, DueDate = new DateTime(2025, 11, 12), SubmittedDate = new DateTime(2025, 11, 11), Status = AssignmentStatus.Graded, Feedback = "Excellent work" },
                new Assignment { Id = 5, GradeId = 5, Name = "ML Final Project", MaxScore = 100, EarnedScore = 95, Weight = 40, DueDate = new DateTime(2025, 11, 15), SubmittedDate = new DateTime(2025, 11, 14), Status = AssignmentStatus.Graded, Feedback = "Outstanding!" },
                new Assignment { Id = 6, GradeId = 6, Name = "OS Lab Report", MaxScore = 100, EarnedScore = 78, Weight = 30, DueDate = new DateTime(2025, 11, 18), SubmittedDate = new DateTime(2025, 11, 17), Status = AssignmentStatus.Graded, Feedback = "Needs improvement" }
            );
        }
    }
}
