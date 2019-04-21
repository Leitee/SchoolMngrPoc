using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Model.Dtos;
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

namespace Pandora.NetCore.Identity
{
    public class AuthSvc : BaseService, IAuthSvc
    {
        private readonly AccountManagerFacade _accountManager;
        private readonly IMapperCore _mapper;
        private readonly AppSettings _settings;

        public AuthSvc(
            IApplicationUow applicationUow,
            ILogger logger,
            IMapperCore mapper,
            AccountManagerFacade accountManager,
            IConfiguration config) : base(applicationUow, logger)
        {
            _mapper = mapper;
            _settings = config.GetSection("AppSettings").Get<AppSettings>();
            _accountManager = accountManager;
        }

        public async Task<string> GetEmailConfirmTokenAsync(UserDto user)
        {
            return await _accountManager.GetEmailConfirmTokenAsync(user);
        }

        public async Task<BLSingleResponse<LoginRespDto>> LoginAsync(LoginDto model)
        {
            var response = new BLSingleResponse<LoginRespDto>();
            //new PasswordHasher<UserDto>().HashPassword(model.Username, pPassword);

            try
            {
                var signInResul = await _accountManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (signInResul == SignInResult.Failed)
                {
                    response.Data = new LoginRespDto("Username or Password is invalid.");
                }
                else if (signInResul == SignInResult.TwoFactorRequired)
                {
                    response.Data = new LoginRespDto("This User does not confirmed email or phone.");
                }
                else if (signInResul == SignInResult.LockedOut)
                {
                    response.Data = new LoginRespDto("This User is currently locked out.");
                }
                else
                {
                    response.Data = TokenBuilder(model.Username, "basic");
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task LogoutAsync()
        {
            await _accountManager.SignOutAsync();
        }

        public async Task<BLSingleResponse<UserDto>> RegisterAsync(RegisterDto model)
        {
            var response = new BLSingleResponse<UserDto>();

            var user = _mapper.MapToBaseClass<UserDto, ApplicationUser>(new UserDto(model.Username, model.Email, model.Firstname, model.Lastname));

            var signUpResul = await _accountManager.SignUpAsync(user, model.Password);

            if (signUpResul.Succeeded)
            {
                var entity = await _accountManager.UserManager.FindByNameAsync(model.Username);
                response.Data = _mapper.MapEntity<ApplicationUser, UserDto>(entity);
            }
            else
            {
                HandleSVCException(response, signUpResul.Errors.ToList().ConvertAll(x => x.Description).ToArray());
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> SendEmailAsync(string email, string callbackUrl)
        {
            var response = new BLSingleResponse<bool>();

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
            var sentResult = await client.SendEmailAsync(msg);
            response.Data = sentResult.StatusCode == System.Net.HttpStatusCode.Accepted;
            return response;
        }

        public async Task<BLSingleResponse<bool>> ConfirmEmailAsync(UserDto user, string token)
        {
            var response = new BLSingleResponse<bool>();

            var confirmResult = await _accountManager.ConfirmEmailAsync(user, token);
            if (confirmResult.Succeeded)
            {
                response.Data = true;
            }
            else
            {
                HandleSVCException(response, confirmResult.Errors.ToList().ConvertAll(x => x.Description).ToArray());
            }

            return response;
        }

        protected LoginRespDto TokenBuilder(string username, string role)
        {
            IEnumerable<Claim> claims = new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
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

            return new LoginRespDto(new JwtSecurityTokenHandler().WriteToken(objToken), expiration);
        }
    }
}
