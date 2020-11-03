using LeaveRequest.Domain.Employees;
using LeaveRequest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveRequest.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(LeaveRequestDbContext context) : base(context)
        {
        }
    }
}
