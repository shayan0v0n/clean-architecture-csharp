using CleanArchtectureTemplate.WebApi.Controllers.v1.Users.Requests;
using FluentValidation;

namespace CleanArchtectureTemplate.WebApi.Controllers.v1.Users.Validators
{
    public class SingUpRequestValidator : AbstractValidator<SingUpRequest>
    {
        public SingUpRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.Password)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is not valid");
        }
    }
}
