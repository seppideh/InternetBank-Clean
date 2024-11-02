using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Application.ApplicationUsers.Exceptions
{
    public class UserNotExistByUsernameAndEmailException : Exception
    {
        public UserNotExistByUsernameAndEmailException() : base("نام کاربری یا ایمیل وارد شده اشتباه است") { }
    }
}