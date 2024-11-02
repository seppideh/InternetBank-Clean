using FluentValidation;
using InternetBank.Application.ApplicationUsers.Exceptions;
using InternetBank.Application.ApplicationUsers.Facade;
using InternetBank.Domain.ApplicationUser.Users.Entities;
using InternetBank.Domain.ApplicationUser.Users.Factories;
using InternetBank.Domain.ApplicationUser.Users.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using System;
using InternetBank.Domain.UnitOfWork;

namespace InternetBank.Application.ApplicationUsers.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, IdentityResult>
    {
        // private readonly IUserRepository _userRepository;
        
        private readonly IUnitOfWork _uow;
        private readonly IValidator<SignUpCommand> _validator;
        private readonly IUserFactories _userFactories;

        public SignUpCommandHandler
        (
            IUnitOfWork uow,
            IValidator<SignUpCommand> validator,
            IUserFactories userFactories
        )


        {
            _uow=uow;
            _validator = validator;
            _userFactories = userFactories;

        }

        public async Task<IdentityResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            // var (firstName, lastName, nationalCode, birthdate, phoneNumber, email, userName) = request;

            // var existingUser = await _userManager.FindByNameAsync(request.UserName);
            var existingUser = await _uow.Users.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new UsernameIsNotUniqueException();
            }

            var validationResult =await _validator.ValidateAsync(request,cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = _userFactories.CreateUser
            (
                request.FirstName,
                request.LastName,
                request.NationalCode,
                request.Birthdate.Date,
                request.PhoneNumber,
                request.Email,
                request.UserName
            );

            await _uow.Users.CreateAsync(user);
            await _uow.SaveChangeAsync();

            return IdentityResult.Success;
        }
    }
}