using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Controllers
{
    [AllowAnonymous]
    public sealed class UserRolesController : ApiController
    {
        public UserRolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> CreateUserRole(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}
