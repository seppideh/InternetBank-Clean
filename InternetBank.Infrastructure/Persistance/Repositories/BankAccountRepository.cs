using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Domain.BankAccounts.Entities;
using InternetBank.Domain.BankAccounts.Repositories;
using InternetBank.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace InternetBank.Infrastructure.Persistance.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly InternetBankContext _context;

        public BankAccountRepository(InternetBankContext context)
        {
            _context = context;
        }

        public void Add(Account account)
            => _context.Accounts.Add(account);
        public async Task<Account> FindByIdAsync(int AccountId)
            => await _context.Accounts
                        .AsQueryable()
                        .Where(x => x.Id == AccountId)
                        .FirstOrDefaultAsync();
    }
}