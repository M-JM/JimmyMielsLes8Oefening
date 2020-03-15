using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.DataAccessLayer.Migrations
{
    public partial class AddSecondPhotoPathColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondPhotoPath",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondPhotoPath",
                table: "Employees");
        }
    }
}
