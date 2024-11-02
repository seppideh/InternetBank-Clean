using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Domain.BankAccount.Enums;
using InternetBank.Domain.BankAccounts.Entities;

namespace InternetBank.Application.BankAccounts.Commands.OpenAccount;

    public record OpenAccountCommandRequest(AccountType AccountType,int Amount):IRequest<Account>
    {
        public int UserId { get; set; }
    }

// public class OpenAccountCommandRequest : IRequest<Account>
// {
//     public AccountType AccountType { get; set; }
//     public int Amount { get; set; }
//     public int UserId { get; set; }

//     public OpenAccountCommandRequest(AccountType accountType, int amount)
//     {
//         AccountType = accountType;
//         Amount = amount;
//     }
// }
