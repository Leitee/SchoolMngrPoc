using Pandora.NetStandard.Core.Security;
using System;

namespace Pandora.NetStandard.Business.Dtos
{
    public class LoginRespDto : TokenResponse
    {
        public bool HasToken { get { return !string.IsNullOrEmpty(Token); } }
        public string MessageResponse { get; set; }

        public LoginRespDto(string token, DateTime expiration)
        {
            Token = token;
            ExpirationDate = (int)expiration.Ticks;
        }

        public LoginRespDto(string  messageResponse)
        {
            MessageResponse = messageResponse;
        }
    }
}
