using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Application.BankAccounts.Commands.OpenAccount
{
    public sealed class OpenAccountCommandValidator : AbstractValidator<OpenAccountCommandRequest>
    {
        public OpenAccountCommandValidator()
        {
            RuleFor(u => u).NotNull().WithMessage("لطفا اطلاعات موردنیاز را وارد کنید");
            RuleFor(u => u.AccountType).NotEmpty().WithMessage("نوع حساب نمی تواند خالی باشد");
            RuleFor(u => u.Amount).NotEmpty().WithMessage("میزان مبلغ برای افتتاح حساب نمی تواند خالی باشد")
            .GreaterThanOrEqualTo(10000).WithMessage("مبلغ برای افتتاح حساب نمی تواند کمتر از 10000 تومان باشد");
        }
    }
}