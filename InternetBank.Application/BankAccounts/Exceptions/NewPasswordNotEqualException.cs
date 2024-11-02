using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Application.BankAccounts.Exceptions
{
    public class NewPasswordNotEqualException : Exception
    {
        public NewPasswordNotEqualException()
            : base("رمز وارد شده اشتباه است") { }
    }
}