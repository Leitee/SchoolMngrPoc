using Pandora.NetStandard.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Services
{
    public interface ISocialSvc
    {
        Task<BLResponse> SignInWithGoogle();
        Task<BLResponse> SignInWithFacebook();
    }
}
