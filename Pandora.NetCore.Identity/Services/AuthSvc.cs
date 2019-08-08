using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.Identity.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Services
{
    public class AuthSvc : BaseService, IAuthSvc
    {
        private readonly AccountManagerFacade _accountManager;
        private readonly IJwtTokenProvider _tokenProvider;
        private readonly IMapperCore _mapper;
        private readonly AppSettings _settings;

        public AuthSvc(
            ILogger logger,
            IMapperCore mapper,
            AccountManagerFacade accountManager,
            IJwtTokenProvider tokenProvider,
            IConfiguration config) : base(logger)
        {
            _mapper = mapper;
            _settings = AppSettings.GetSettings(config ?? throw new ArgumentNullException(nameof(config)));
            _accountManager = accountManager;
            _tokenProvider = tokenProvider;
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
                var signInResul = await _accountManager.SignInAsync(model.Username, model.Password, model.RememberMe);

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
                    var user = await _accountManager.UserManager.FindByNameAsync(model.Username);
                    var role = await _accountManager.GetRoleByUserAsync(user);

                    if (role != null)
                    {
                        var tokenResul = _tokenProvider.GenerateToken(user, role);
                        response.Data = new LoginRespDto { Token = tokenResul.Token, ExpirationDate = tokenResul.ExpirationDate };
                    }
                    else
                    {
                        response.Data = new LoginRespDto("This User has no role assigned.");
                        await _accountManager.SignOutAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLResponse> LogoutAsync()
        {
            await _accountManager.SignOutAsync();
            return BLResponse.GetVoidResponse();
        }

        public async Task<BLSingleResponse<UserDto>> RegisterAsync(RegisterDto model)
        {
            var response = new BLSingleResponse<UserDto>();

            var user = _mapper.MapToBaseClass<UserDto, ApplicationUser>(new UserDto(model.Username, model.Email, model.FirstName, model.LastName));

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
    }
}
