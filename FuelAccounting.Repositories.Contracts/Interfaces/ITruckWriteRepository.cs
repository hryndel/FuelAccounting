using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий записи <see cref="Truck"/>
    /// </summary>
    public interface ITruckWriteRepository : IRepositoryWriter<Truck>
    {
    }
}
