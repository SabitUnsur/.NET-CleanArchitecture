
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CleanArchitecture.WebApi.Configurations
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("SqlConnection"));
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext() //enrich: contexten gelen değerlerde daha detaylı loglama sağlar 
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) //her gün yeni bir log dosyası oluşturur
                .WriteTo.PostgreSQL(
                    connectionString: configuration.GetConnectionString("SqlConnection"),
                    tableName: "Logs",
                    needAutoCreateTable: true)
                .CreateLogger();

            host.UseSerilog();
        }
    }
}
