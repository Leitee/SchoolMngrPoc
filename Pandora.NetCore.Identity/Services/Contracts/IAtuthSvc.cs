using Pandora.NetStdLibrary.Base.Base;
using Pandora.NetStdLibrary.Base.Identity;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Services.Contracts
{
    public interface IAuthSvc : IAuthSvc<UserDto>
    {

    }

    public interface IAuthSvc<TUser> where TUser : ApplicationUser
    {
        Task<BLSingleResponse<LoginRespDto>> LoginAsync(LoginDto model);
        Task<BLSingleResponse<TUser>> RegisterAsync(RegisterDto model);
        Task<BLResponse> LogoutAsync();
        Task<string> GetEmailConfirmTokenAsync(TUser user);
        Task<BLSingleResponse<bool>> SendEmailAsync(string pEmail, string pUrlRedirect);
        Task<BLSingleResponse<bool>> ConfirmEmailAsync(TUser user, string token);
    }
}
