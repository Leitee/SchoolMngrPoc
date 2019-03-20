using NetCore.ServiceData.Dtos;
using System.Threading.Tasks;

namespace NetCore.ServiceData.Services.Contracts
{
    public interface IAccountSvc
    {   
        Task<TokenRespDto> LoginAsync(LoginDto model);
        Task<TokenRespDto> RegisterAsync(RegisterDto model);
    }
}
