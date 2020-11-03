using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveRequest.Domain.Employees.ValueObjects
{
    public class EmployeeName
    {
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        public string DisplayName => string.Join(" ", FirstName, LastName);
    }
}
