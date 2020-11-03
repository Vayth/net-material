using LeaveRequest.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveRequest.Domain.Employees
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
    }
}
