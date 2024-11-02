using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Domain.ApplicationUser.Users.Factories
{
    public interface IUserFactories
    {
        User CreateUser
        (
         string firstName,
         string lastName,
         string nationalCode,
         DateTime birthdate,
         string phoneNumber,
         string email,
         string userName
        );
    }
}