using System.Threading.Tasks;
using Pandora.NetStandard.BusinessData.Dtos;
using Pandora.NetStandard.Core.Bases;

namespace Pandora.NetStandard.BusinessData.Services.Contracts
{
    public interface IAccountSvc
    {   
        Task<BLSingleResponse<TokenRespDto>> LoginAsync(LoginDto model);
        Task<BLSingleResponse<TokenRespDto>> RegisterAsync(RegisterDto model);
    }
}
