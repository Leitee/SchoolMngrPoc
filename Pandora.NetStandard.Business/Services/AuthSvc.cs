using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Interfaces.Identity;
using Pandora.NetStandard.Core.Identity;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.Extensions.Configuration;
using Pandora.NetStandard.Core.Config;
using System.Linq;

namespace Pandora.NetStandard.Business.Services
{
    public class AuthSvc : BaseService, IAuthSvc
    {
        private readonly ISignInManagerFacade _signInManager;
        private readonly AppSettings _config;

        public AuthSvc(IApplicationUow applicationUow, ISignInManagerFacade signInManager, IConfiguration config) : base(applicationUow)
        {
            _signInManager = signInManager;
            _config = config.GetSection("AppSettings").Get<AppSettings>();
        }

        public async Task<BLSingleResponse<TokenRespDto>> LoginAsync(LoginDto model)
        {
            var response = new BLSingleResponse<TokenRespDto>();

            var signInResul = await _signInManager.SignInAsync(model.Username, model.Password, model.RememberMe);

            if (signInResul == SignInResult.Failed)
            {
                HandleSVCException(response, "Username or Password is invalid.");
            }
            else if (signInResul == SignInResult.TwoFactorRequired)
            {
                HandleSVCException(response, "User did not confirm email.");
            }
            else if (signInResul == SignInResult.LockedOut)
            {
                HandleSVCException(response, "This User is currently locked out.");
            }
            else
            {
                response.Data = TokenBuilder(model.Username, "regular");
            }

            return response;
        }

        public async Task<BLSingleResponse<TokenRespDto>> RegisterAsync(RegisterDto model)
        {
            var response = new BLSingleResponse<TokenRespDto>();

            var user = new ApplicationUser(model.Username, model.Email, model.Firstname, model.Lastname);

            var signInResul = await _signInManager.SignUpAsync(user, model.Password, new[] { new ApplicationRole("regular", string.Empty) });

            if (!signInResul.Succeeded)
            {
                HandleSVCException(response, signInResul.Errors.ToList().ConvertAll(x => x.Description).ToArray());
            }
            else
            {
                response.Data = TokenBuilder(model.Username, "regular");
            }

            return response;
        }

        private TokenRespDto TokenBuilder(string username, string role)
        {
            IEnumerable<Claim> claims = new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.JwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            var objToken = new JwtSecurityToken(
                issuer: _config.JwtValidIssuer,
                audience: _config.JwtValidAudience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new TokenRespDto(new JwtSecurityTokenHandler().WriteToken(objToken), expiration);
        }
    }
}
