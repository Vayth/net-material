using LeaveRequest.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Application.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeAppService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            employee.CreatedBy = employee.Email;
            employee.CreatedTime = DateTime.Now;
            await _employeeRepository.AddAsync(employee);
            return employee;
        }
    }
}
