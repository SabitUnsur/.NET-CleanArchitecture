using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Services
{
    public sealed class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUserRoleAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            UserRole userRole = new UserRole
            {
                UserId = request.UserId,
                RoleId = request.RoleId
            };

            await _userRoleRepository.AddAsync(userRole,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
