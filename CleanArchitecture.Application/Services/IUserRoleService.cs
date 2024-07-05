using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IUserRoleService
    {
        Task CreateUserRoleAsync(CreateUserRoleCommand request,CancellationToken cancellationToken);
    }
}
