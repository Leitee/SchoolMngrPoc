using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Security.Identity;
using System.Threading.Tasks;

namespace Pandora.NetStandard.BusinessData.Services.Contracts
{
    public interface IAccountSvc 
    {
        Task<BLListResponse<ApplicationRole>> GetAllRolesAsync();
        Task<BLSingleResponse<ApplicationRole>> GetRoleByIdAsync(string pId);
        Task<BLSingleResponse<ApplicationRole>> GetRoleByNameAsync(string pRolName);
        Task<BLSingleResponse<ApplicationRole>> CreateRoleAsync(ApplicationRole pDto);
        Task<BLSingleResponse<bool>> UpdateRoleAsync(ApplicationRole pDto);
        Task<BLSingleResponse<bool>> DeleteRoleAsync(ApplicationRole pDto);

        Task<BLListResponse<ApplicationUser>> GetAllUsersAsync();
        Task<BLSingleResponse<ApplicationUser>> GetUserByIdAsync(string pId);
        Task<BLSingleResponse<ApplicationUser>> GetUserByNameAsync(string pUserName);
        Task<BLSingleResponse<ApplicationUser>> CreateUserAsync(ApplicationUser pDto);
        Task<BLSingleResponse<bool>> UpdateUserAsync(ApplicationUser pDto);
        Task<BLSingleResponse<bool>> DeleteUserAsync(ApplicationUser pDto);
    }
}
