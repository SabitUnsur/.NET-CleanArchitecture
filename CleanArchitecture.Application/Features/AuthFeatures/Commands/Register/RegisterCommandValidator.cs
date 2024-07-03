using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p=>p.Email).NotEmpty().EmailAddress();
            RuleFor(p=>p.UserName).NotEmpty().NotNull().MinimumLength(3).WithMessage("At least 3 character");
            RuleFor(p=>p.Password).NotEmpty().NotNull().WithMessage("NOT NULL");
            RuleFor(p=>p.Password).Matches("[A-Z]").WithMessage("At least one uppercase letter")
                .Matches("[a-z]").WithMessage("At least one lowercase letter")
                .Matches("[0-9]").WithMessage("At least one digit")
                .Matches("[^a-zA-Z0-9]").WithMessage("At least one special character")
        }
    }
}
