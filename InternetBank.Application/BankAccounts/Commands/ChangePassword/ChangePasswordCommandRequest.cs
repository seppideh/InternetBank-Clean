using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Application.BankAccounts.Commands.ChangePassword
{
    public record ChangePasswordCommandRequest
        (
         int AccountId,
         string OldPassword,
         string NewPassword,
         string RepeatNewPassword
        ) : IRequest;
}