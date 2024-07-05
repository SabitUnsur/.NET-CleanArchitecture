using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Authorization
{
    //Bu sınıf,RoleAttribute sınıfında IUserRepository olarak bir servis çağrıldığı için, doğrudan controllerda [RoleFilter()] olarak yazım yapamadıgımız için yazıldı.
    public sealed class RoleFilterAttribute : TypeFilterAttribute
    {
        public RoleFilterAttribute(string role) : base(typeof(RoleAttribute))
        {
            Arguments = new object[] { role };
        }
    }
}
