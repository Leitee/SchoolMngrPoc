using FluentValidation;
using Pandora.NetStandard.Model.Dtos;

namespace Pandora.NetCore.Identity.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).MinimumLength(6);
            RuleFor(x => x.Password).MinimumLength(6);
        }
    }
}
