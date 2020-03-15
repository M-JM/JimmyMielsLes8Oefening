using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.DataAccessLayer.Migrations
{
    public partial class SeedEmployeesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BankAccountNumber", "Department", "Email", "Name" },
                values: new object[] { 1, "BE12 1234 1234 1234", 2, "test@test.com", "Wim" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
