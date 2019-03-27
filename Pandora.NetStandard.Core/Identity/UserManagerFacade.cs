using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pandora.NetStandard.Core.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Identity
{
    public class UserManagerFacade : UserManagerFacade<ApplicationUser>, IUserRepository
    {
        public UserManagerFacade(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }

    public class UserManagerFacade<TUser> : UserManager<TUser>, IUserRepository<TUser> where TUser : ApplicationUser
    {
        public UserManagerFacade(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public async Task<IdentityResult> CreateAsync<TRole>(TUser user, IEnumerable<TRole> roles) where TRole : ApplicationRole
        {
            //IdentityResult result = await CreateAsync(user);
            //if (!result.Succeeded) return result;
            var a = roles.ToList().ConvertAll(x => x.Name);
            return await AddToRolesAsync(await FindByNameAsync(user.UserName), roles.ToList().ConvertAll(x => x.Name));
        }

        public async Task<IdentityResult> DeleteAsync(int UserId)
        {
            var user = await FindByIdAsync(UserId);
            return await DeleteAsync(user);
        }

        public async Task<TUser> FindByIdAsync(int userId)
        {
            return await FindByIdAsync(userId.ToString());
        }

        public async Task<IQueryable<TUser>> GetAllUsersAsync()
        {
            return await Task.Run(() =>
            {
                return Users;
            });
        }
    }
}
