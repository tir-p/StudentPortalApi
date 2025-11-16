using StudentPortalApi.Data;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Repositories;
using StudentPortalApi.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Prevent circular reference issues when returning entities with navigation properties
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Register Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with SQL Server
// Connection string is read from appsettings.json
builder.Services.AddDbContext<StudentPortalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories (Data Access Layer)
// Scoped lifetime: one instance per HTTP request
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<ICourseScheduleRepository, CourseScheduleRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IAttendanceRecordRepository, AttendanceRecordRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();

// Register Services (Business Logic Layer)
// Scoped lifetime: one instance per HTTP request
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<ICourseScheduleService, CourseScheduleService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IAttendanceRecordService, AttendanceRecordService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

// Register AutoMapper (will scan for all profiles in the assembly)
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
