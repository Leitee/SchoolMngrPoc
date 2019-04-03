using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class AuthSvc : BaseService, IAuthSvc
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppSettings _settings;

        public AuthSvc(IApplicationUow applicationUow, SignInManager<ApplicationUser> signInManager, IConfiguration config) : base(applicationUow)
        {
            _signInManager = signInManager;
            _settings = config.GetSection("AppSettings").Get<AppSettings>();
        }

        public async Task<string> GetEmailConfirmTokenAsync(ApplicationUser user)
        {
            return await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<BLSingleResponse<TokenRespDto>> LoginAsync(LoginDto model)
        {
            var response = new BLSingleResponse<TokenRespDto>();
            //new PasswordHasher<ApplicationUser>().HashPassword(model.Username, pPassword);
            var signInResul = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

            if (signInResul == SignInResult.Failed)
            {
                HandleSVCException(response, "Username or Password is invalid.");
            }
            else if (signInResul == SignInResult.TwoFactorRequired)
            {
                HandleSVCException(response, "This User does not confirmed email.");
            }
            else if (signInResul == SignInResult.LockedOut)
            {
                HandleSVCException(response, "This User is currently locked out.");
            }
            else
            {
                response.Data = TokenBuilder(model.Username, "basic");
            }

            return response;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<BLSingleResponse<ApplicationUser>> RegisterAsync(RegisterDto model)
        {
            var response = new BLSingleResponse<ApplicationUser>();

            var user = new ApplicationUser(model.Username, model.Email, model.Firstname, model.Lastname);

            var signUpResul = await _signInManager.UserManager.CreateAsync(user, model.Password);

            if (signUpResul.Succeeded)
            {
                response.Data = await _signInManager.UserManager.FindByNameAsync(model.Username);
            }
            else
            {
                HandleSVCException(response, signUpResul.Errors.ToList().ConvertAll(x => x.Description).ToArray());
            }

            return response;
        }

        public async Task SendEmailAsync(string email, string callbackUrl)
        {
            var client = new SendGridClient(_settings.SendGridApiKey);
            var msg = MailHelper.CreateSingleEmail(
                new EmailAddress(_settings.SendGridFrom, _settings.SendGridUserSender),
                new EmailAddress(email),
                _settings.SendGridSubject,
                "Thank you for register.",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var resp = await client.SendEmailAsync(msg);
            //resp.StatusCode == System.Net.HttpStatusCode.
        }

        protected TokenRespDto TokenBuilder(string username, string role)
        {
            IEnumerable<Claim> claims = new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            var objToken = new JwtSecurityToken(
                issuer: _settings.JwtValidIssuer,
                audience: _settings.JwtValidAudience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new TokenRespDto(new JwtSecurityTokenHandler().WriteToken(objToken), expiration);
        }
    }
}
