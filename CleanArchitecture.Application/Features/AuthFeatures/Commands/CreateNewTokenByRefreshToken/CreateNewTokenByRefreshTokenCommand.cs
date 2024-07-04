using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
    public sealed record CreateNewTokenByRefreshTokenCommand
    (
        string userId,
        string RefreshToken
    ) : IRequest<LoginCommandResponse>;
}
