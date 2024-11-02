using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Domain.ApplicationUser.Users.Repositories;
using InternetBank.Domain.BankAccounts.Repositories;

namespace InternetBank.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBankAccountRepository BankAccounts { get; }

        Task SaveChangeAsync();

    }
}