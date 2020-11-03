using LeaveRequest.Application.Accounts.Dto;
using LeaveRequest.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Application.Accounts
{
    public class AccountAppService : IAccountAppService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountAppService> _logger;
        private readonly IConfiguration _config;

        public AccountAppService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<AccountAppService> logger,
            IConfiguration config)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
            this._config = config;
        }

        public async Task<AccountRegisterDto> RegisterAsync(AccountRegisterDto employee)
        {
            IdentityUser identityUser = new IdentityUser(employee.Email);
            var identityResult = await _userManager.CreateAsync(identityUser, employee.Password);
            if (!identityResult.Succeeded)
                throw new UserRegisterException(identityResult.Errors.ToDictionary(x => x.Code, x => x.Description));
            return employee;
        }

        public async Task<string> LoginAsync(UserLoginDto userLogin)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, false, false);
            if (signInResult.Succeeded)
            {
                string token = GenerateToken(userLogin);
                return token;
            }
            throw new FailedSignInException();
        }

        private string GenerateToken(UserLoginDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
