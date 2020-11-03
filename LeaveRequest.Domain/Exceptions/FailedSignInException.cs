using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveRequest.Domain.Exceptions
{
    public class FailedSignInException : Exception
    {
        public FailedSignInException()
        {
        }

        public FailedSignInException(string message) : base(message)
        {
        }
    }
}
