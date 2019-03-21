using Pandora.NetStandard.BusinessData.Dtos;
using Pandora.NetStandard.BusinessData.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Security.Identity;
using System.Threading.Tasks;

namespace Pandora.NetStandard.BusinessData.Services
{
    public class AccountSvc : BaseService, IAccountSvc
    {
        public AccountSvc(IApplicationUow applicationUow) : base(applicationUow)
        {
        }

        public async Task<BLSingleResponse<TokenRespDto>> LoginAsync(LoginDto model)
        {
            var response = new BLSingleResponse<TokenRespDto>();

            //implement

            if (response.HasErrors)
            {
                HandleSVCException(response, "Username or Password is invalid");
            }

            return response;
        }

        public async Task<BLSingleResponse<TokenRespDto>> RegisterAsync(RegisterDto model)
        {
            var response = new BLSingleResponse<TokenRespDto>();

            //implement

            if (response.HasErrors)
            {
                HandleSVCException(response, "There was an error, user was not created");
            }   

            return response;
        }
    }
}
