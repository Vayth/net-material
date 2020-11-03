using LeaveRequest.Domain.Employees.ValueObjects;
using LeaveRequest.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LeaveRequest.Domain.Employees
{
    public class Employee : Entity<Guid>
    {
        public Employee()
        {
            Name = new EmployeeName();
            Address = new Address();
        }

        [Required]
        public EmployeeName Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Address Address { get; set; }
        public Guid? PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
