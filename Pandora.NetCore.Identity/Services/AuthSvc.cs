using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Core.Security;
using Pandora.NetStandard.Model.Dtos;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity
{
    public class AuthSvc : BaseService, IAuthSvc
    {
        private readonly AccountManagerFacade _accountManager;
        private readonly IMapperCore _mapper;
        private readonly IConfiguration _config;

        public AuthSvc(
            IApplicationUow applicationUow,
            ILogger logger,
            IMapperCore mapper,
            AccountManagerFacade accountManager,
            IConfiguration config) : base(applicationUow, logger)
        {
            _mapper = mapper;
            _config = config;
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
                    var user = _mapper.MapEntity<ApplicationUser, UserDto>(await _accountManager.UserManager.FindByNameAsync(model.Username));
                    user.Role = _mapper.MapEntity<ApplicationRole, RoleDto>(await _accountManager.GetRoleByUserAsync(user));

                    var tokenResul = new JwtTokenProvider(_config).GenerateToken(user);
                    response.Data = new LoginRespDto { Token = tokenResul.Token, ExpirationDate = tokenResul.ExpirationDate };
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
            AppSettings settings = AppSettings.GetSettings(_config);

            var client = new SendGridClient(AppSettings.GetSettings(_config).SendGridApiKey);
            var msg = MailHelper.CreateSingleEmail(
                new EmailAddress(settings.SendGridFrom, settings.SendGridUserSender),
                new EmailAddress(email),
                settings.SendGridSubject,
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
    }
}
