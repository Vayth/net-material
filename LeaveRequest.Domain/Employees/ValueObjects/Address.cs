using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveRequest.Domain.Employees.ValueObjects
{
    public class Address
    {
        [Required]
        public string Street { get; set; } = "";
        [Required]
        public string City { get; set; } = "";
    }
}
