namespace CleanArchitecture.WebApi.Configurations
{
    //Program.cs dosyasındaki servislerin tanınması, program.csdeki kod kalabalığından kurtulmak için tasarlandı. 
    //IHostBuilder, serilog için kullanılmıştır.
    public interface IServiceInstaller
    {
        void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder host);
    }
}
