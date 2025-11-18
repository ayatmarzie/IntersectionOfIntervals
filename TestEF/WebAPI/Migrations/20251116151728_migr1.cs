using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class migr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemesterID",
                table: "Enrollment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_SemesterID",
                table: "Enrollment",
                column: "SemesterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Semester_SemesterID",
                table: "Enrollment",
                column: "SemesterID",
                principalTable: "Semester",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Semester_SemesterID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_SemesterID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "SemesterID",
                table: "Enrollment");
        }
    }
}
