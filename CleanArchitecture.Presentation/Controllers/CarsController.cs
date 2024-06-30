using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
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
    public sealed class CarsController : ApiController
    {
        public CarsController(IMediator mediator) : base(mediator){}

        [HttpPost("[action]")] // POST: api/Cars/Create
        public async Task<IActionResult> Create(CreateCarCommand request,CancellationToken cancellationToken)
        {
            MessageResponse response =  await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
