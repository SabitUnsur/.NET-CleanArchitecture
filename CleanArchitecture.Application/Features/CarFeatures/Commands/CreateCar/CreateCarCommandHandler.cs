using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar
{
    public sealed class CreateCarCommandHandler: IRequestHandler<CreateCarCommand, MessageResponse>
    {
        private readonly ICarService _carService;

        public CreateCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _carService.CreateAsync(request, cancellationToken);
            return new MessageResponse("Car Created Successfully!");
        }
    }
}
