using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Application.BankAccounts.Commands.ChangePassword;
using InternetBank.Application.BankAccounts.Commands.OpenAccount;
using InternetBank.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InternetBank.Application.BankAccounts
{
    public static class Extensions
    {
        internal static IServiceCollection AddBankAccount(this IServiceCollection services)
        {
            // DI Bank Accounts Commands and Queries Handlers
            services.AddTransient<IValidator<OpenAccountCommandRequest>, OpenAccountCommandValidator>();
            services.AddTransient<IValidator<ChangePasswordCommandRequest>, ChangePasswordCommandValidator>();


            services.AddTransient<IAccountNumberGeneratorService, AccountNumberGeneratorService>();

            return services;

        }
    }
}