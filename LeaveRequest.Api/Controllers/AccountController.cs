using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveRequest.Application.Accounts;
using LeaveRequest.Application.Accounts.Dto;
using LeaveRequest.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LeaveRequest.Api.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountAppService accountAppService, ILogger<AccountController> logger)
        {
            this._accountAppService = accountAppService;
            this._logger = logger;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountRegisterDto>> RegisterAsync(AccountRegisterDto employee)
        {
            try
            {
                await _accountAppService.RegisterAsync(employee);
                return Ok(employee);
            }
            catch (UserRegisterException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Errors);
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserTokenDto>> LoginAsync(UserLoginDto user)
        {
            try
            {
                string token = await _accountAppService.LoginAsync(user);
                return Ok(token);
            }
            catch (UserRegisterException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
