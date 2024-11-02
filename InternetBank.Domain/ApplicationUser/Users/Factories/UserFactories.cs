using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Domain.ApplicationUser.Users.Factories
{
    public class UserFactories : IUserFactories
    {
        public User CreateUser(string firstName, string lastName, string nationalCode,DateTime birthdate, string phoneNumber, string email, string userName)
        {
            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                NationalCode = nationalCode,
                Birthdate = birthdate,
                PhoneNumber = phoneNumber,
                Email = email,
                UserName = userName
            };
        }
    }
}