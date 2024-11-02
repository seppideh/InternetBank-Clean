
using Microsoft.AspNetCore.Identity;

namespace InternetBank.Application.ApplicationUsers.Commands.SignUp
{
  public class SignUpCommand : IRequest<IdentityResult>
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string NationalCode { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
  }

}
