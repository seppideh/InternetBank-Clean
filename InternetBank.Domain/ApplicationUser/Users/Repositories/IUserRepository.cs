using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBank.Domain.ApplicationUser.Users.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(User user);
        Task<User> FindByNameAsync(string UserName);
        Task<User?> FindAsyncByUsernameAndEmail(string Email, string UserName);
    }
}