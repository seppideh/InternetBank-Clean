using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Domain.ApplicationUser.Users.Repositories;
using InternetBank.Domain.ApplicationUser.Users.Factories;
using InternetBank.Infrastructure.Persistance.Context;
using InternetBank.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InternetBank.Domain.UnitOfWork;
using InternetBank.Infrastructure.Persistance.UnitOfWorks;
using InternetBank.Domain.BankAccounts.Repositories;

namespace InternetBank.Infrastructure.Persistance
{
    internal static class Extensions
    {
        internal static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            // DI Repositories and UnitOfWork
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // DI Factories
            services.AddTransient<IUserFactories, UserFactories>();

            var options = configuration.GetConnectionString("InternetBankConnectionStrings");
            services.AddDbContext<InternetBankContext>(ctx =>
            ctx.UseNpgsql(options));

            return services;
        }
    }
}