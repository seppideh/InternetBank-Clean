using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Application.ApplicationUsers.Queries.LoginUser
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQueryRequest>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("نام کاربری نمی تواند خالی باشد");

            RuleFor(x => x.Email).NotEmpty().WithMessage("ایمیل نمی تواند خالی باشد");
        }
    }
}