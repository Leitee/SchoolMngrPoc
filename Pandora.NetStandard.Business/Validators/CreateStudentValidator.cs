using FluentValidation;
using Pandora.NetStandard.Model.Dtos;

namespace Pandora.NetStandard.Business.Validators
{
    public class CreateStudentValidator : AbstractValidator<StudentDto>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.ApplicationUserId).NotEmpty();
            RuleFor(x => x.Address).MinimumLength(10);
        }
    }
}
