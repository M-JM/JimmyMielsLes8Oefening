using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.DataAccessLayer.Migrations
{
    public partial class AlterEmployeesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "wim@test.com");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BankAccountNumber", "Department", "Email", "Name" },
                values: new object[] { 2, "BE12 1234 1234 1234", 1, "jack@test.com", "Jack" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "test@test.com");
        }
    }
}
