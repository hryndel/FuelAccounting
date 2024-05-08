using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="FuelAccountingItem"/>
    /// </summary>
    public interface IFuelAccountingItemWriteRepository : IRepositoryWriter<FuelAccountingItem>
    {
    }
}
