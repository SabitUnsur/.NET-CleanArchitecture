 using CleanArchitecture.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Authorization
{
    public sealed class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role; //kontrol edilecek rol
        private readonly IUserRoleRepository _userRoleRepository;
        public RoleAttribute(string role, IUserRoleRepository userRoleRepository)
        {
            _role = role;
            _userRoleRepository = userRoleRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier); //kullanıcının id'si
            
            if(userIdClaim == null)
            {
                context.Result = new UnauthorizedResult(); //kullanıcı yoksa yetkisiz sayfasına yönlendir
                return;
            }

            var userHasRole = _userRoleRepository
                .GetWhere(x => x.UserId == userIdClaim.Value)
                .Include(p => p.Role)
                .Any(p => p.Role.Name == _role);
            if (!userHasRole) {
                context.Result = new UnauthorizedResult(); //kullanıcı yoksa yetkisiz sayfasına yönlendir
                return;
            }
        }
    }
}
    