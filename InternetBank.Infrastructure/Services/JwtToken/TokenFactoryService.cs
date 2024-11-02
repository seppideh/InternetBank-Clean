using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InternetBank.Application.ApplicationUsers.ExternalServices.Jwt;
using InternetBank.Application.ExternalServices.Jwt;
using InternetBank.Domain.ApplicationUser.Users.Entities;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InternetBank.Infrastructure.Services.JwtToken
{
    public class TokenFactoryService : ITokenFactoryService
    {
        private readonly IConfiguration _configuration;

        public TokenFactoryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtTokensData CreateJwtTokensAsync(User user)
        {
            var accessToken = CreateAccesTokenAsync(user);
            return new JwtTokensData
            {
                AccessToken = accessToken
            };
        }

        private string CreateAccesTokenAsync(User user)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["BearerTokens:Secret"]));

            var token = new JwtSecurityToken(
              issuer: _configuration["BearerTokens:ValidIssuer"],
              audience: _configuration["BearerTokens:ValidAudiance"],
              expires: DateTime.Now.AddDays(1),
              claims: authClaims,
              signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}