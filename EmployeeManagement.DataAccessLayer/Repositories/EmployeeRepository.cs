using System.Collections.Generic;
using EmployeeManagement.DataAccessLayer.Context;
using EmployeeManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            var listEmployees = _context.Employees;
            return listEmployees;
        }

        public Employee GetById(int id)
        {
            var employee = _context.Employees.Find(id);
            return employee;
        }

        public Employee Add(Employee employee)
        {
            var newEmployee = _context.Employees.Add(employee);

            if (newEmployee != null && newEmployee.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newEmployee.Entity;
                }
            }

            return null;
        }

        public Employee Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
            {
                var deletedEmployee = _context.Employees.Remove(employee);

                if (deletedEmployee != null && deletedEmployee.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedEmployee.Entity;
                    }
                }
            }

            return null;
        }

        public Employee Update(Employee employee)
        {
            var newEmployee = _context.Employees.Update(employee);

            if (newEmployee != null && newEmployee.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newEmployee.Entity;
                }
            }

            return null;
        }
    }
}
