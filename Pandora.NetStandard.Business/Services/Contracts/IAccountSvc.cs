using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface IAccountSvc : IAccountSvc<UserDto, RoleDto>
    {

    }

    public interface IAccountSvc<TUser, TRole> where TRole : ApplicationRole
    {
        Task<BLSingleResponse<LoginRespDto>> LoginAsync(LoginDto model);
        Task LogoutAsync();
        Task<BLSingleResponse<bool>> ConfirmEmailAsync(TUser user, string token);

        Task<BLListResponse<TRole>> GetAllRolesAsync();
        Task<BLSingleResponse<TRole>> GetRoleByIdAsync(int pId);
        Task<BLSingleResponse<TRole>> GetRoleByNameAsync(string pRolName);
        Task<BLSingleResponse<TRole>> CreateRoleAsync(TRole pDto);
        Task<BLSingleResponse<bool>> UpdateRoleAsync(TRole pDto);
        Task<BLSingleResponse<bool>> DeleteRoleAsync(TRole pDto);

        Task<BLListResponse<TUser>> GetAllUsersAsync();
        Task<BLSingleResponse<TUser>> GetUserByIdAsync(int pId);
        Task<BLSingleResponse<TUser>> GetUserByNameAsync(string pUserName);
        Task<BLSingleResponse<TUser>> CreateUserAsync(TUser pDto);
        Task<BLSingleResponse<bool>> UpdateUserAsync(TUser pDto);
        Task<BLSingleResponse<bool>> DeleteUserAsync(TUser pDto);
    }
}
