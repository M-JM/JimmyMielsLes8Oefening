using EmployeeManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccessLayer.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Wim",
                    Department = Department.IT,
                    Email = "wim@test.com",
                    BankAccountNumber = "BE12 1234 1234 1234",
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jack",
                    Department = Department.HR,
                    Email = "jack@test.com",
                    BankAccountNumber = "BE12 1234 1234 1234",
                }
            );
        }
    }
}
