using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InternetBank.Domain.ApplicationUser.Users.Entities;
using Microsoft.EntityFrameworkCore;
using InternetBank.Domain.BankAccounts.Entities;
using InternetBank.Domain.Transactions.Entities;

namespace InternetBank.Infrastructure.Persistance.Context
{
    public class InternetBankContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public InternetBankContext(DbContextOptions<InternetBankContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankTransaction> Transactions { get; set; }
    }
}