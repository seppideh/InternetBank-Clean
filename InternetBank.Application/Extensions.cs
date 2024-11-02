using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using InternetBank.Application.ApplicationUsers;
using InternetBank.Application.BankAccounts;
using Microsoft.Extensions.DependencyInjection;

namespace InternetBank.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddUser();
            services.AddBankAccount();
            
            var assembly = Assembly.GetExecutingAssembly();
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(assembly);

            return services;
        }
    }
}