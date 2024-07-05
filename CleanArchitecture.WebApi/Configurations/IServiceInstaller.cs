namespace CleanArchitecture.WebApi.Configurations
{
    //Program.cs dosyasındaki servislerin tanınması, program.csdeki kod kalabalığından kurtulmak için tasarlandı. 
    public interface IServiceInstaller
    {
        void Install(IServiceCollection services, IConfiguration configuration);
    }
}
