using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Application.ApplicationUsers.Exceptions
{
    public class UsernameIsNotUniqueException : Exception
    {
        public UsernameIsNotUniqueException()
            : base("این نام کاربری تکراری است. لطفا نام کاربری دیگری انتخاب کنید") { }
    }
}