﻿using CleanArchtectureTemplate.WebApi.Controllers.v1.Users.Requests;
using FluentValidation;

namespace CleanArchtectureTemplate.WebApi.Controllers.v1.Users.Validators
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.AccessToken)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is not valid");
        }
    }
}
