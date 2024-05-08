using FuelAccounting.Common;
using Microsoft.Extensions.DependencyInjection;
using FuelAccounting.Shared;

namespace FuelAccounting.Repositories
{
    public class RepositoryModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IRepositoryAnchor>(ServiceLifetime.Scoped);
        }
    }
}
