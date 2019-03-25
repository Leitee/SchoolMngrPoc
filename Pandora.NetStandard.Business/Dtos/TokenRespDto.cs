using System;

namespace Pandora.NetStandard.Business.Dtos
{
    public class TokenRespDto
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool HasToken { get { return !string.IsNullOrEmpty(Token); } }
    }
}
