using System.Reflection;

namespace CleanArchitecture.WebApi.Configurations
{
    public static class DependencyInjection

    {   //IServiceInstaller metodunu implemente eden sınıfları bulup, Install metodunu çağırır.
        public static IServiceCollection InstallServices(
            this IServiceCollection services,
            IConfiguration configuration,
            params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> serviceInstallers = assemblies
                .SelectMany(s => s.DefinedTypes)
                .Where(IsAssignableToType<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();

            foreach (IServiceInstaller serviceInstaller in serviceInstallers)
            {
                serviceInstaller.Install(services, configuration);
            }

            return services;
               
        }

        public static bool IsAssignableToType<T>(TypeInfo typeInfo) => 
            typeof(T).IsAssignableFrom(typeInfo)
            && !typeInfo.IsInterface 
            && !typeInfo.IsAbstract;
        
    }
}
