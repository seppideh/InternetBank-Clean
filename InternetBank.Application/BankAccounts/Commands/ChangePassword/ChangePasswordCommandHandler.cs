using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Application.BankAccounts.Exceptions;
using InternetBank.Domain.BankAccounts.Repositories;
using InternetBank.Domain.UnitOfWork;

namespace InternetBank.Application.BankAccounts.Commands.ChangePassword
{
    public sealed class ChangePasswordCommandHandler : IRequest<ChangePasswordCommandRequest>
    {
        private readonly IUnitOfWork _uow;

        public ChangePasswordCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var account = await _uow.BankAccounts.FindByIdAsync(request.AccountId);

            if (account.StaticPassword != request.OldPassword)
            {
                throw new NewPasswordNotEqualException();
            }
            account.StaticPassword = request.NewPassword;

            await _uow.SaveChangeAsync();


        }
    }
}