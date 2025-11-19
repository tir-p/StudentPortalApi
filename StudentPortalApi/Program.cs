using Microsoft.EntityFrameworkCore;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Repositories;
using StudentPortalApi.Services;
using System.Text.Json.Serialization;
using StudentPortal.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Prevents infinite loops when objects reference each other.
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true; //Makes JSON pretty-printed with indentation.
        // Converts C# property names (PascalCase) to camelCase in JSON property FirstName becomes firstName in json
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        // Serialize enums as strings instead of integers - CamelCase option makes it "first" instead of "First". instead of "year": 1 it will be "year": "first"
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase));
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

// Add CORS to allow frontend to call the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.AllowAnyOrigin()            // TEMP FOR DEV ONLY
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS - MUST be before UseHttpsRedirection and UseAuthorization
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
