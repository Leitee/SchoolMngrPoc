using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pandora.NetStandard.Core.Security
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        protected readonly AppSettings _settings;

        public JwtTokenProvider(IConfiguration config)
        {
            _settings = AppSettings.GetSettings(config ?? throw new ArgumentNullException(nameof(config)));
        }

        public virtual TokenResponse GenerateToken<TUser, TRole>(TUser pUser, TRole pRole) where TUser : ApplicationUser where TRole : ApplicationRole
        {
            IEnumerable<Claim> claims = new[] {
                new Claim("userdata", JsonConvert.SerializeObject(pUser).ToLower()),//TODO: get rid ToLower and fix Json parsing
                new Claim("userrole", JsonConvert.SerializeObject(pRole).ToLower()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())//to generate random token
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = _settings.IsProdMode ? DateTime.UtcNow.AddHours(12) : DateTime.UtcNow.AddMonths(1);

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
