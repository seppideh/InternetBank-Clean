using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Domain.BankAccounts.Repositories
{
    public interface IBankAccountRepository
    {
        void Add(Account account);
        Task<Account> FindByIdAsync(int AccountId);
    }
}