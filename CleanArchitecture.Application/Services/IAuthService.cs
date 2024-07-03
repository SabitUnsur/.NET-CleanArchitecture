using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterCommand request);
    }
}
