using InternetBank.Application.ExternalServices.Jwt;
using InternetBank.Domain.ApplicationUser.Users.Entities;

namespace InternetBank.Application.ApplicationUsers.ExternalServices.Jwt
{
    public interface ITokenFactoryService
    {
        JwtTokensData CreateJwtTokensAsync(User user);
    }
}