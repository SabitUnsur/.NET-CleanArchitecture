using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar
{
    //WebApi katmanından gelecek istekte ne isteniyorsa onu belirtmek için kullanılır. 
    //DTO (Data Transfer Object) olarak düşünülebilir.
    //IRequest<> içine dönüş tipi yazılır.
    public sealed record CreateCarCommand(
        string Name,
        string Model,
        int EnginePower
    ) : IRequest<MessageResponse>;
}
