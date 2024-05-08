using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий записи <see cref="Fuel"/>
    /// </summary>
    public interface IFuelWriteRepository : IRepositoryWriter<Fuel>
    {
    }
}
