
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebApi.Configurations
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);
            services.AddDbContext<AppDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("SqlConnection"));
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
