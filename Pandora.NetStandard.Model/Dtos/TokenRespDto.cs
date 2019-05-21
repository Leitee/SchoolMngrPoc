using System;
using Reinforced.Typings.Attributes;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "LoginResp")]
    public sealed class LoginRespDto
    {
        public string Token { get; set; }
        public int ExpirationDate { get; set; }
        public bool HasToken { get { return !string.IsNullOrEmpty(Token); } }
        public string MessageResponse { get; set; }

        public LoginRespDto(string messageResponse = null)
        {
            MessageResponse = messageResponse;
        }

        public LoginRespDto(string token, DateTime expiration)
        {
            Token = token;
            ExpirationDate = (int)expiration.Ticks;
        }
    }
}
