using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
    public sealed class CreateNewTokenByRefreshTokenCommandValidator:AbstractValidator<CreateNewTokenByRefreshTokenCommand>
    {
        public CreateNewTokenByRefreshTokenCommandValidator()
        {
            RuleFor(p => p.userId).NotEmpty().NotNull().WithMessage("User info is required.");
            RuleFor(p => p.RefreshToken).NotEmpty().NotNull().WithMessage("Refresh token info is required.");
        }
    }
}
