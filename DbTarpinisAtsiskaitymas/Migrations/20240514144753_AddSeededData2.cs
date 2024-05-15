using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbTarpinisAtsiskaitymas.Migrations
{
    /// <inheritdoc />
    public partial class AddSeededData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Electrical Engineering" },
                    { 3, "Mathematics" },
                    { 4, "Civil Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "LectureId", "LectureName" },
                values: new object[,]
                {
                    { 1, "Introduction to Programming" },
                    { 2, "Algorithms and Data Structures" },
                    { 3, "Civil Engineering Fundamentals" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentLecture",
                columns: new[] { "DepartmentId", "LectureId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DepartmentId", "FirstName", "LastName" },
                values: new object[] { 1, 1, "Jonas", "Jonauskas" });

            migrationBuilder.InsertData(
                table: "StudentLecture",
                columns: new[] { "LectureId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DepartmentLecture",
                keyColumns: new[] { "DepartmentId", "LectureId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DepartmentLecture",
                keyColumns: new[] { "DepartmentId", "LectureId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentLecture",
                keyColumns: new[] { "LectureId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentLecture",
                keyColumns: new[] { "LectureId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);
        }
    }
}
