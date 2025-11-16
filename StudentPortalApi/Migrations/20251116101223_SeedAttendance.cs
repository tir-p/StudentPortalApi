using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentPortalApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AttendanceRecords",
                columns: new[] { "Id", "AttendanceId", "ClassType", "Date", "Remarks", "Status" },
                values: new object[,]
                {
                    { 3, 1, 0, new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 4, 1, 0, new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arrived 10 minutes late", 2 },
                    { 5, 1, 0, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 6, 1, 0, new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medical leave", 1 },
                    { 7, 1, 0, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 8, 1, 0, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 9, 1, 0, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 10, 1, 0, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 11, 1, 0, new DateTime(2025, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 12, 1, 0, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 13, 1, 0, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 14, 1, 0, new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 15, 1, 0, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 16, 1, 0, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 17, 1, 0, new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 18, 1, 0, new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 19, 1, 0, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 20, 1, 0, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "Id", "AttendancePercentage", "AttendedClasses", "CourseCode", "CourseId", "CourseName", "Status", "StudentId", "TotalClasses" },
                values: new object[,]
                {
                    { 2, 72.200000000000003, 13, "CSE-4102", 2, "Machine Learning", 1, 1, 18 },
                    { 3, 100.0, 16, "CSE-4103", 3, "Cloud Computing", 0, 1, 16 },
                    { 4, 60.0, 12, "CSE-4104", 4, "Operating Systems", 2, 1, 20 }
                });

            migrationBuilder.InsertData(
                table: "AttendanceRecords",
                columns: new[] { "Id", "AttendanceId", "ClassType", "Date", "Remarks", "Status" },
                values: new object[,]
                {
                    { 21, 2, 1, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 22, 2, 1, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 23, 2, 1, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal emergency", 1 },
                    { 24, 2, 1, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 25, 2, 1, new DateTime(2025, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arrived 15 minutes late", 2 },
                    { 26, 2, 1, new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 27, 2, 1, new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 28, 2, 1, new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 29, 2, 1, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 30, 2, 1, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 31, 2, 1, new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 32, 2, 1, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Official university event", 3 },
                    { 33, 2, 1, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 34, 2, 1, new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 35, 2, 1, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 36, 2, 1, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 37, 2, 1, new DateTime(2025, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 38, 2, 1, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 39, 3, 0, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 40, 3, 0, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 41, 3, 0, new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 42, 3, 0, new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 43, 3, 0, new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 44, 3, 0, new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 45, 3, 0, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 46, 3, 0, new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 47, 3, 0, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 48, 3, 0, new DateTime(2025, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 49, 3, 0, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 50, 3, 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 51, 3, 0, new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 52, 3, 0, new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 53, 3, 0, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 54, 3, 0, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 55, 4, 0, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 56, 4, 0, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Missed class", 1 },
                    { 57, 4, 0, new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 58, 4, 0, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 59, 4, 0, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 60, 4, 0, new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medical appointment", 1 },
                    { 61, 4, 0, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arrived 20 minutes late", 2 },
                    { 62, 4, 0, new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 63, 4, 0, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 64, 4, 0, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 65, 4, 0, new DateTime(2025, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 66, 4, 0, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 67, 4, 0, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 68, 4, 0, new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 69, 4, 0, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 70, 4, 0, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 71, 4, 0, new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 72, 4, 0, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 73, 4, 0, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 74, 4, 0, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
