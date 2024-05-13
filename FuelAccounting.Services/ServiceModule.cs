using FuelAccounting.Common;
using FuelAccounting.Services.Automappers;
using FuelAccounting.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace FuelAccounting.Services
{
    public class ServiceModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IServiceAnchor>(ServiceLifetime.Scoped);
            service.RegisterAutoMapperProfile<ServiceProfile>();
        }
    }
}
