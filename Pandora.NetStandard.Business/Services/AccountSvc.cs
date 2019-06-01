using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Pandora.NetStandard.Business.Services
{
    public class AccountSvc : BaseService, IAccountSvc
    {
        private readonly AccountManagerFacade _accountManager;
        private readonly IMapperCore _mapper;
        private readonly AppSettings _settings;

        public AccountSvc(IApplicationUow applicationUow,
            AccountManagerFacade signInManager,
            ILogger<AccountSvc> logger,
            IConfiguration config,
            IMapperCore mapper) : base(applicationUow, logger)
        {
            _accountManager = signInManager;
            _mapper = mapper;
            _settings = AppSettings.GetSettings(config);
        }

        #region Auth
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
        #endregion

        #region User
        public Task<BLSingleResponse<bool>> DeleteUserAsync(UserDto pDto)
        {
            throw new NotImplementedException();
        }
        public Task<BLSingleResponse<UserDto>> CreateUserAsync(UserDto pDto)
        {
            throw new NotImplementedException();
        }
        public async Task<BLListResponse<UserDto>> GetAllUsersAsync()
        {
            var response = new BLListResponse<UserDto>();

            try
            {
                var resul = await _uow.Users.GetAllAsync();
                response.Data = _mapper.MapEntity<ApplicationUser, UserDto>(resul);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
        public async Task<BLSingleResponse<UserDto>> GetUserByIdAsync(int pId)
        {
            var response = new BLSingleResponse<UserDto>();
            try
            {
                var result = await _uow.Users.FindByIdAsync(pId);
                response.Data = _mapper.MapEntity<ApplicationUser, UserDto>(result);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }
            return response;
        }
        public Task<BLSingleResponse<UserDto>> GetUserByNameAsync(string pUserName)
        {
            throw new NotImplementedException();
        }
        public Task<BLSingleResponse<bool>> UpdateUserAsync(UserDto pDto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Role
        public Task<BLSingleResponse<RoleDto>> CreateRoleAsync(RoleDto pDto)
        {
            throw new NotImplementedException();
        }
        public Task<BLSingleResponse<bool>> DeleteRoleAsync(RoleDto pDto)
        {
            throw new NotImplementedException();
        }
        public async Task<BLListResponse<RoleDto>> GetAllRolesAsync()
        {
            var response = new BLListResponse<RoleDto>();

            try
            {
                var result = await _uow.Roles.GetAllAsync();
                response.Data = _mapper.MapEntity<ApplicationRole, RoleDto>(result);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
        public Task<BLSingleResponse<RoleDto>> GetRoleByIdAsync(int pId)
        {
            throw new NotImplementedException();
        }
        public Task<BLSingleResponse<RoleDto>> GetRoleByNameAsync(string pRolName)
        {
            throw new NotImplementedException();
        }
        public Task<BLSingleResponse<bool>> UpdateRoleAsync(RoleDto pDto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
