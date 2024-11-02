using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Domain.BankAccounts.Entities;
using InternetBank.Domain.Services;
using InternetBank.Domain.UnitOfWork;

namespace InternetBank.Application.BankAccounts.Commands.OpenAccount
{
    public class OpenAccountCommandHandler : IRequestHandler<OpenAccountCommandRequest, Account>
    {
        private readonly IAccountNumberGeneratorService _bankAccountGenerator;
        private readonly IUnitOfWork _uow;
        public OpenAccountCommandHandler(IAccountNumberGeneratorService bankAccountGenerator, IUnitOfWork uow)
        {
            _bankAccountGenerator = bankAccountGenerator;
            _uow = uow;
        }

        public async Task<Account> Handle(OpenAccountCommandRequest request, CancellationToken cancellationToken)
        {
            var account = new Account()
            {
                AccountType = request.AccountType,
                Amount = request.Amount,
                AccountNumber = _bankAccountGenerator.AccountNumberGenerator(request.UserId, request),
                CardNumber = _bankAccountGenerator.CardNumberGenerator(),
                CVV2 = _bankAccountGenerator.Cvv2Generator(),
                ExpireDate = DateTime.Now.AddYears(5).ToString("yy/MM"),
                StaticPassword = _bankAccountGenerator.PasswordGenerator(),
                IsBlocked = false,
                UserId = request.UserId
            };

            _uow.BankAccounts.Add(account);
            await _uow.SaveChangeAsync();
            return account;
        }
    }
}