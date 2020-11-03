using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveRequest.Application.Accounts.Dto
{
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserTokenDto
    {
        public string Token { get; set; }
    }
}
