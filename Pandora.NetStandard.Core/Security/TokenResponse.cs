using System;

namespace Pandora.NetStandard.Core.Security
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public int ExpirationDate { get; set; }
    }
}
