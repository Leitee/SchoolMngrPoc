using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pandora.NetStandard.Core.Security
{
    public class JwtTokenProvider
    {
        private readonly AppSettings _settings;

        public JwtTokenProvider(IConfiguration config)
        {
            _settings = config.GetSection("AppSettings").Get<AppSettings>() ?? throw new ArgumentNullException(nameof(config));
        }

        public virtual TokenResponse GenerateToken<TUser>(TUser pUser) where TUser : ApplicationUser
        {
            IEnumerable<Claim> claims = new[] {
                new Claim("userdata", JsonConvert.SerializeObject(pUser).ToLower()),//TODO: get rid tolower
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(12);

            var objToken = new JwtSecurityToken(
                issuer: _settings.JwtValidIssuer,
                audience: _settings.JwtValidAudience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new TokenResponse(new JwtSecurityTokenHandler().WriteToken(objToken), expiration);
        }
    }
}
