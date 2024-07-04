using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {   
            MessageResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("[action]")] // api/auth/login
        public async Task<IActionResult> Login(LoginCommand request,CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _mediator.Send(request,cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request,CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _mediator.Send(request,cancellationToken);
            return Ok(response);
        }
    }
}
