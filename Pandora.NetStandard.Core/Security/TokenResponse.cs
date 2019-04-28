using System;

namespace Pandora.NetStandard.Core.Security
{
    public class TokenResponse
    {
        public string Token { get; private set; }
        public int ExpirationDate { get; private set; }

        public TokenResponse(string pToken, DateTime pExpDate)
        {
            Token = pToken;
            ExpirationDate = (int)pExpDate.Ticks;//TODO: check result
        }
    }
}
