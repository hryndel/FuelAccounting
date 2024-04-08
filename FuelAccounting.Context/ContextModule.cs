using FuelAccounting.Common;
using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FuelAccounting.Context
{
    public class ContextModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.TryAddScoped<IFuelAccountingContext>(provider => provider.GetRequiredService<FuelAccountingContext>());
            service.TryAddScoped<IDbReader>(provider => provider.GetRequiredService<FuelAccountingContext>());
            service.TryAddScoped<IDbWriter>(provider => provider.GetRequiredService<FuelAccountingContext>());
            service.TryAddScoped<IUnitOfWork>(provider => provider.GetRequiredService<FuelAccountingContext>());
        }
    }
}
