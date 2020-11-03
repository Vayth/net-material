using LeaveRequest.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveRequest.Domain.Employees
{
    public class Position : Entity<Guid>
    {
        [Required]
        public string Name { get; set; }
        public Guid? ReportToPositionId { get; set; }
        public virtual Position ReportToPosition { get; set; }
    }
}
