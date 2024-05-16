using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbTarpinisAtsiskaitymas.Migrations
{
    /// <inheritdoc />
    public partial class pluralizeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_LectureId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLecture_Lectures_LectureId",
                table: "StudentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLecture_Students_StudentId",
                table: "StudentLecture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLecture",
                table: "StudentLecture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentLecture",
                table: "DepartmentLecture");

            migrationBuilder.RenameTable(
                name: "StudentLecture",
                newName: "StudentLectures");

            migrationBuilder.RenameTable(
                name: "DepartmentLecture",
                newName: "DepartmentLectures");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLecture_LectureId",
                table: "StudentLectures",
                newName: "IX_StudentLectures_LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLecture_LectureId",
                table: "DepartmentLectures",
                newName: "IX_DepartmentLectures_LectureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLectures",
                table: "StudentLectures",
                columns: new[] { "StudentId", "LectureId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentLectures",
                table: "DepartmentLectures",
                columns: new[] { "DepartmentId", "LectureId" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "Email",
                value: "jonas.jonauskas@gmail.com");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLectures_Departments_DepartmentId",
                table: "DepartmentLectures",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLectures_Lectures_LectureId",
                table: "DepartmentLectures",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLectures_Lectures_LectureId",
                table: "StudentLectures",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLectures_Students_StudentId",
                table: "StudentLectures",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLectures_Departments_DepartmentId",
                table: "DepartmentLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLectures_Lectures_LectureId",
                table: "DepartmentLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLectures_Lectures_LectureId",
                table: "StudentLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLectures_Students_StudentId",
                table: "StudentLectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLectures",
                table: "StudentLectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentLectures",
                table: "DepartmentLectures");

            migrationBuilder.RenameTable(
                name: "StudentLectures",
                newName: "StudentLecture");

            migrationBuilder.RenameTable(
                name: "DepartmentLectures",
                newName: "DepartmentLecture");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLectures_LectureId",
                table: "StudentLecture",
                newName: "IX_StudentLecture_LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLectures_LectureId",
                table: "DepartmentLecture",
                newName: "IX_DepartmentLecture_LectureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLecture",
                table: "StudentLecture",
                columns: new[] { "StudentId", "LectureId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentLecture",
                table: "DepartmentLecture",
                columns: new[] { "DepartmentId", "LectureId" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "Email",
                value: "jonas.jonaskas@gmail.com");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentId",
                table: "DepartmentLecture",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_LectureId",
                table: "DepartmentLecture",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLecture_Lectures_LectureId",
                table: "StudentLecture",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLecture_Students_StudentId",
                table: "StudentLecture",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
