using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Application.ApplicationUsers.Exceptions;
using InternetBank.Application.ApplicationUsers.ExternalServices.Jwt;
using InternetBank.Application.ExternalServices.Jwt;
using InternetBank.Domain.ApplicationUser.Users.Entities;
using InternetBank.Domain.ApplicationUser.Users.Repositories;
using Microsoft.AspNetCore.Identity;


namespace InternetBank.Application.ApplicationUsers.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQueryRequest, JwtTokensResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<LoginUserQueryRequest> _validator;
        private readonly ITokenFactoryService _tokenFactory;

        public LoginUserQueryHandler
        (
            IUserRepository userRepository,
            IValidator<LoginUserQueryRequest> validator,
            ITokenFactoryService tokenFactory
        )
        {
            _userRepository = userRepository;
            _validator = validator;
            _tokenFactory = tokenFactory;
        }

        public async Task<JwtTokensResponse> Handle(LoginUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsyncByUsernameAndEmail(request.Email, request.UserName) ?? throw new UserNotExistByUsernameAndEmailException();
            var token = _tokenFactory.CreateJwtTokensAsync(user);
            return new JwtTokensResponse { AccessToken = token.AccessToken };
        }
    }
}