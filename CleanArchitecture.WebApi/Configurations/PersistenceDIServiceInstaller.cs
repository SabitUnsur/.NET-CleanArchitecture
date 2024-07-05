
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Persistance.Services;
using GenericRepository;
using System.Net;
using System.Net.Mail;

namespace CleanArchitecture.WebApi.Configurations
{
    public sealed class PersistenceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder host)
        {
           services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
           services.AddScoped<ICarService, CarService>();
           services.AddSingleton(new SmtpClient("sabitunsur@gmail.com")
            {
                Credentials = new NetworkCredential("username", "password"),
                EnableSsl = true
            });
           services.AddScoped<IAuthService, AuthService>();
           services.AddScoped<IRoleService, RoleService>();
           services.AddScoped<IUserRoleRepository, UserRoleRepository>();
           services.AddScoped<IUserRoleService, UserRoleService>();
           services.AddScoped<ICarRepository, CarRepository>();

        }
    }
}
