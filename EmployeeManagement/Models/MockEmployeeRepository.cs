using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.DataAccessLayer.Models;
using EmployeeManagement.DataAccessLayer.Repositories;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1, Name="Wim", Department=Department.IT, Email="test@test.com", BankAccountNumber="BE12 1234 1234 1234"},
                new Employee(){Id=2, Name="Jack", Department=Department.HR, Email="jack@test.com", BankAccountNumber="BE12 1234 1234 1234"},
                new Employee(){Id=3, Name="Pol", Department=Department.Payroll, Email="pol@test.com", BankAccountNumber="BE12 1234 1234 1234"},
            };
        }

        public Employee GetById(int Id)
        {
            //throw new NotImplementedException();
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var oldEmployee = _employeeList.FirstOrDefault(e => e.Id == employee.Id);

            if (oldEmployee != null)
            {
                oldEmployee.Name = employee.Name;
                oldEmployee.BankAccountNumber = employee.BankAccountNumber;
                oldEmployee.Department = employee.Department;
                oldEmployee.Email = employee.Email;
            }

            return oldEmployee;
        }

        public Employee Delete(int id)
        {
            var employee = _employeeList.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                _employeeList.Remove(employee);
            }

            return employee;
        }
    }
}
