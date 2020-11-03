using LeaveRequest.Application.Accounts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Application.Accounts
{
    public interface IAccountAppService
    {
        Task<AccountRegisterDto> RegisterAsync(AccountRegisterDto employee);
        Task<string> LoginAsync(UserLoginDto userLogin);
    }
}
