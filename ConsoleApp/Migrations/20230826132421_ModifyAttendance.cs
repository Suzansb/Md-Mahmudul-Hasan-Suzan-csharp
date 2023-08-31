using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class ModifyAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_CourseId",
                table: "Attendance",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendance",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Courses_CourseId",
                table: "Attendance",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Students_StudentId",
                table: "Attendance",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Courses_CourseId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Students_StudentId",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_CourseId",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Attendance");
        }
    }
}
