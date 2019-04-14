using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Identity;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface IAuthSvc : IAuthSvc<UserDto>
    {

    }

    public interface IAuthSvc<TUser> where TUser : ApplicationUser
    {
        Task<BLSingleResponse<LoginRespDto>> LoginAsync(LoginDto model);
        Task<BLSingleResponse<TUser>> RegisterAsync(RegisterDto model);
        Task LogoutAsync();
        Task<string> GetEmailConfirmTokenAsync(TUser user);
        Task<BLSingleResponse<bool>> SendEmailAsync(string pEmail, string pUrlRedirect);
        Task<BLSingleResponse<bool>> ConfirmEmailAsync(TUser user, string token);
    }
}
