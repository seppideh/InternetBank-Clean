using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Application.ApplicationUsers.Commands.SignUp;
using InternetBank.Application.ApplicationUsers.Queries.LoginUser;

namespace InternetBank.Application.ApplicationUsers.Facade
{
    public interface IUserFacade
    {
        SignUpCommandHandler SignUp { get; }
        LoginUserQueryHandler LoginUser { get; }
    }

    public class UserFacade : IUserFacade
    {
        private readonly SignUpCommandHandler _signUp;
        private readonly LoginUserQueryHandler _loginUser;

        public UserFacade(SignUpCommandHandler signUp, LoginUserQueryHandler loginUser)
        {
            _signUp = signUp;
            _loginUser = loginUser;
        }

        public SignUpCommandHandler SignUp => _signUp;
        public LoginUserQueryHandler LoginUser => _loginUser;
    }
}