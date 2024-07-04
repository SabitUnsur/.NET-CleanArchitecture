using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Abstraction
{
    //Bu sınıfı, tüm controllerda aynı kodları tekrar etmemek için oluşturduk.
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")] //bu kodun amacı, bu controller'ın api/values gibi bir endpoint'i olduğunu belirtmek
    public abstract class ApiController : ControllerBase
    {
        //CQRS istek atabilmek için IMediator interface'ini kullanıyoruz.
        public readonly IMediator _mediator;

        public ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
