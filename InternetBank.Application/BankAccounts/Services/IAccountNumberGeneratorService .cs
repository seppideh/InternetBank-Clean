using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Application.BankAccounts.Commands.OpenAccount;

namespace InternetBank.Domain.Services
{
    public interface IAccountNumberGeneratorService 
    {
        string AccountNumberGenerator(int userId, OpenAccountCommandRequest request);
        string CardNumberGenerator();
        string Cvv2Generator();
        public string PasswordGenerator();
    }
}