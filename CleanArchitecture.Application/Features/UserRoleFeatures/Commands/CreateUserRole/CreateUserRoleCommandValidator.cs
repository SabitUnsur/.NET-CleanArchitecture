using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole
{
    public sealed class CreateUserRoleCommandValidator:AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            RuleFor(p=>p.UserId).NotEmpty().NotNull().WithMessage("UserId cannot be null");
            RuleFor(p => p.RoleId).NotEmpty().NotNull().WithMessage("RoleId cannot be null");
        }
    }
}
