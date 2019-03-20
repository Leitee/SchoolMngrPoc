using System.Threading.Tasks;
using Pandora.NetStandard.BusinessData.Dtos;

namespace Pandora.NetStandard.BusinessData.Services.Contracts
{
    public interface IAccountSvc
    {   
        Task<TokenRespDto> LoginAsync(LoginDto model);
        Task<TokenRespDto> RegisterAsync(RegisterDto model);
    }
}
