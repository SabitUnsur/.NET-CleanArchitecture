using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
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
    public sealed class RolesController : ApiController
    {
        public RolesController(IMediator mediator) : base(mediator){}

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand request,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request,cancellationToken));
        }
    }
}
