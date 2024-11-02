using System.Linq;
using System.Threading.Tasks;
using InternetBank.Domain.ApplicationUser.Users.Entities;
using InternetBank.Domain.ApplicationUser.Users.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InternetBank.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserRepository(
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        public async Task<IdentityResult> CreateAsync(User user)
            => await _userManager.CreateAsync(user);
        public async Task<User> FindByNameAsync(string UserName)
            => await _userManager.FindByNameAsync(UserName);
        public async Task<User> FindAsyncByUsernameAndEmail(string Email, string UserName)
            => await _userManager.Users
                             .AsQueryable()
                             .Where(x => x.UserName.ToLower() == UserName.ToLower()
                                      && x.Email.ToLower() == Email.ToLower())
                             .FirstOrDefaultAsync();
    }
}