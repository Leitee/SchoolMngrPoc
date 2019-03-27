using Pandora.NetStandard.Core.Security;
using System;

namespace Pandora.NetStandard.Business.Dtos
{
    public class TokenRespDto : TokenResponse
    {
        public bool HasToken { get { return !string.IsNullOrEmpty(Token); } }

        public TokenRespDto(string token, DateTime expiration)
        {
            Token = token;
            ExpirationDate = (int)expiration.Ticks;
        }
    }
}
