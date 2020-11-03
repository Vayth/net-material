using LeaveRequest.Application.Employees;
using LeaveRequest.Application.Employees.Dto;
using LeaveRequest.Domain.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            this._employeeAppService = employeeAppService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails),StatusCodes.Status400BadRequest)]
        public ActionResult<AddEmployeeDto> Add(AddEmployeeDto employeeDto)
        {
            Employee employee = new Employee();
            employee.Name.FirstName = employeeDto.FirstName;
            employee.Name.LastName = employeeDto.LastName;
            employee.Email = employeeDto.Email;
            _employeeAppService.CreateAsync(employee);
            return Ok(employeeDto);
        }
    }
}
