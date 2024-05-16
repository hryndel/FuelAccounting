using Microsoft.Extensions.DependencyInjection;

namespace FuelAccounting.Common
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterModule<TModule>(this IServiceCollection services) where TModule : Module
        {
            var type = typeof(TModule);
            var instance = Activator.CreateInstance(type) as TModule;
            instance?.CreateModule(services);
        }
    }
}
