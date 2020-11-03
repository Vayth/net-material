using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveRequest.Domain.Exceptions
{
    public class UserRegisterException : Exception
    {
        public IDictionary<string, string> Errors { get; private set; }
        public UserRegisterException(IDictionary<string, string> errors) : base()
        {
            Errors = errors;
        }
    }
}
