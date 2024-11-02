using FluentValidation;
using InternetBank.Domain.ApplicationUser.Users.Entities;
using InternetBank.Domain.ApplicationUser.Users.Repositories;
using Microsoft.AspNetCore.Identity;


namespace InternetBank.Application.ApplicationUsers.Commands.SignUp
{
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        private readonly UserManager<User> _userManager;

        public SignUpCommandValidator(
            UserManager<User> userManager)
        {
            _userManager = userManager;


            RuleFor(x => x.FirstName).NotEmpty().WithMessage("لطفا نام خود را وارد کنيد")
                                    .Length(3, 50).WithMessage("نام وارد شده نمی تواند کمتر از 3 و بیشتر از 50 کاراکتر داشته باشد")
                                    .Matches(@"^[\u0600-\u06FF\s]+$").WithMessage("لطفا نام خود را فارسي وارد کنيد");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("لطفا نام خانوادگی خود را وارد کنيد")
                                    .Length(3, 50).WithMessage("نام خانوادگی وارد شده نمی تواند کمتر از 3 و بیشتر از 50 کاراکتر داشته باشد")
                                    .Matches(@"^[\u0600-\u06FF\s]+$").WithMessage("لطفا نام خود را فارسي وارد کنيد");
            RuleFor(x => x.NationalCode)
                                    .NotEmpty().WithMessage("لطفا کد ملی خود را وارد کنید")
                                    .Length(10).WithMessage("کد ملی بایستی 10 رقمی باشد.")
                                    .Must(BeAValidIranianNationalCode).WithMessage("کد ملی وارد شده معتبر نیست");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("نام کاربری نمی تواند خالی باشد")
                                  .Length(2, 10).WithMessage("نام کاربری وارد شده نمی تواند کمتر از 2 و بیشتر از 10 کاراکتر داشته باشد")
                                  .MustAsync(BeUniqueUsername).WithMessage("نام کاربری وارد شده تکراری است");

        }

        private bool BeAValidIranianNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10)
            {
                return false;
            }

            if (!long.TryParse(nationalCode, out _))
            {
                return false;
            }

            // Check for all digits being the same
            if (new string(nationalCode[0], 10) == nationalCode)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(nationalCode[i].ToString()) * (10 - i);
            }

            int remainder = sum % 11;
            int checkDigit = int.Parse(nationalCode[9].ToString());

            return (remainder < 2 && checkDigit == remainder) || (remainder >= 2 && checkDigit == 11 - remainder);
        }

        private async Task<bool> BeUniqueUsername(string Username, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByNameAsync(Username);
            return existingUser == null;
        }

    }
}