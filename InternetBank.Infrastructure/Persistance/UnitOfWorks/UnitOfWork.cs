using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Domain.ApplicationUser.Users.Repositories;
using InternetBank.Domain.BankAccounts.Repositories;
using InternetBank.Domain.UnitOfWork;
using InternetBank.Infrastructure.Persistance.Context;

namespace InternetBank.Infrastructure.Persistance.UnitOfWorks
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly InternetBankContext _context;
        private readonly IUserRepository _users;
        private readonly IBankAccountRepository _bankAccounts;

        public UnitOfWork
            (InternetBankContext context,
            IUserRepository users,
            IBankAccountRepository bankAccounts
            )
        {
            _context = context;
            _users = users;
            _bankAccounts = bankAccounts;
        }

        public IUserRepository Users => _users;
        public IBankAccountRepository BankAccounts => _bankAccounts;
        public async Task SaveChangeAsync() => await _context.SaveChangesAsync();
    }
}