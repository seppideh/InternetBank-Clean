using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Application.ApplicationUsers.ExternalServices.Jwt;
using InternetBank.Infrastructure.Services.JwtToken;
using Microsoft.Extensions.DependencyInjection;

namespace InternetBank.Infrastructure.Services
{
    public static class Extensions
    {
        internal static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenFactoryService, TokenFactoryService>();
            return services;
        }
    }
}