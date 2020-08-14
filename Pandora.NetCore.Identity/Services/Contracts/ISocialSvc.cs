using Microsoft.AspNetCore.Authentication;
using Pandora.NetStdLibrary.Base.Base;
using Pandora.NetStdLibrary.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Services.Contracts
{
    public interface ISocialSvc
    {
        Task<BLListResponse<string>> GetAllSocialProvidersAsync();
        Task<BLSingleResponse<string>> HandleExternalLoginAsync();
        Task<BLSingleResponse<AuthenticationProperties>> SignInWithFacebookAsync(string redirectUrl);
        Task<BLSingleResponse<AuthenticationProperties>> SignInWithGoogleAsync(string redirectUrl);
    }
}
