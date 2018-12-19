using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeWebsite.Migrations
{
    public partial class CourseID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CourseNumber",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseID",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "CourseNumber",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
