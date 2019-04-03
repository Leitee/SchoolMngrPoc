﻿using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Identity;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface IAccountSvc : IAccountSvc<ApplicationUser, ApplicationRole>, IAuthSvc
    {

    }

    public interface IAccountSvc<TUser, TRole> : IAuthSvc<TUser> where TUser : ApplicationUser where TRole : ApplicationRole
    {
        Task<BLListResponse<TRole>> GetAllRolesAsync();
        Task<BLSingleResponse<TRole>> GetRoleByIdAsync(string pId);
        Task<BLSingleResponse<TRole>> GetRoleByNameAsync(string pRolName);
        Task<BLSingleResponse<TRole>> CreateRoleAsync(TRole pDto);
        Task<BLSingleResponse<bool>> UpdateRoleAsync(TRole pDto);
        Task<BLSingleResponse<bool>> DeleteRoleAsync(TRole pDto);

        Task<BLListResponse<TUser>> GetAllUsersAsync();
        Task<BLSingleResponse<TUser>> GetUserByIdAsync(string pId);
        Task<BLSingleResponse<TUser>> GetUserByNameAsync(string pUserName);
        Task<BLSingleResponse<TUser>> CreateUserAsync(TUser pDto);
        Task<BLSingleResponse<bool>> UpdateUserAsync(TUser pDto);
        Task<BLSingleResponse<bool>> DeleteUserAsync(TUser pDto);
    }
}