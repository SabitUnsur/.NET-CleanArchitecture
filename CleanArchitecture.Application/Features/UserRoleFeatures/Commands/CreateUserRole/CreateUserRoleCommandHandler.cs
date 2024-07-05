using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole
{
    public sealed class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, MessageResponse>
    {
        private readonly IUserRoleService _userRoleService;

        public CreateUserRoleCommandHandler(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _userRoleService.CreateUserRoleAsync(request, cancellationToken);
            return new MessageResponse("Role assigned to User Successfully");
        }
    }
}
