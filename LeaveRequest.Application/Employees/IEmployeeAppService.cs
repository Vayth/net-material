using LeaveRequest.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Application.Employees
{
    public interface IEmployeeAppService
    {
        Task<Employee> CreateAsync(Employee employee);
    }
}
