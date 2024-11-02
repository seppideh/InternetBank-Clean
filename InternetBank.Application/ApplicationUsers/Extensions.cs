using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using InternetBank.Application.ApplicationUsers.Commands.SignUp;
using InternetBank.Application.ApplicationUsers.Facade;
using InternetBank.Application.ApplicationUsers.Queries.LoginUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace InternetBank.Application.ApplicationUsers
{
    public static class Extensions
    {
        internal static IServiceCollection AddUser(this IServiceCollection services)
        {
            // DI User Commands and Queries Handlers
            services.AddTransient<IRequestHandler<SignUpCommand, IdentityResult>, SignUpCommandHandler>();
            services.AddTransient<IValidator<SignUpCommand>, SignUpCommandValidator>();
            
            services.AddTransient<IValidator<LoginUserQueryRequest>, LoginUserQueryValidator>();

            // DI User Facade
            // services.AddTransient<IUserFacade, UserFacade>();

            return services;

        }

    }
}