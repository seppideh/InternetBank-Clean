using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Application.ApplicationUsers.Exceptions
{
    public class InternetBankBadRequestBaseExceptions : Exception
    {
        protected InternetBankBadRequestBaseExceptions(string message)
            : base(message) {}
    }
}