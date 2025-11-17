using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentPortalApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdditionalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Feedback",
                value: "Excellent work!");

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseCode", "CourseId", "CourseName", "Credits", "GradePoints", "LetterGrade", "Semester", "StudentId", "TotalScore" },
                values: new object[,]
                {
                    { 2, "CSE-4102", 2, "Machine Learning", 4, 3.0, 4, "fall-2025", 1, 85.0 },
                    { 3, "CSE-4101", 1, "Advanced Software Engineering", 3, 3.5, 4, "fall-2025", 1, 88.0 },
                    { 4, "CSE-4103", 3, "Cloud Computing", 3, 4.0, 1, "fall-2025", 1, 92.0 },
                    { 5, "CSE-4102", 2, "Machine Learning", 4, 4.0, 1, "fall-2025", 1, 95.0 },
                    { 6, "CSE-4104", 4, "Operating Systems", 3, 2.0, 7, "fall-2025", 1, 78.0 }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "DueDate", "EarnedScore", "Feedback", "GradeId", "MaxScore", "Name", "Status", "SubmittedDate", "Weight" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0, "Good implementation", 2, 100.0, "ML Project", 2, new DateTime(2025, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0 },
                    { 3, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.0, "Well done", 3, 100.0, "Software Engineering Assignment", 2, new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0 },
                    { 4, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.0, "Excellent work", 4, 100.0, "Cloud Deployment Lab", 2, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0 },
                    { 5, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.0, "Outstanding!", 5, 100.0, "ML Final Project", 2, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0 },
                    { 6, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.0, "Needs improvement", 6, 100.0, "OS Lab Report", 2, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Feedback",
                value: "Excellent work on implementing the Factory pattern!");
        }
    }
}
