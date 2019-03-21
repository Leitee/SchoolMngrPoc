using Pandora.NetStandard.BusinessData.Dtos;
using Pandora.NetStandard.Core.Bases;
using System.Threading.Tasks;

namespace Pandora.NetStandard.BusinessData.Services.Contracts
{
    public interface IAuthSvc
    {
        Task<BLSingleResponse<TokenRespDto>> LoginAsync(LoginDto model);
        Task<BLSingleResponse<TokenRespDto>> RegisterAsync(RegisterDto model);
    }
}
