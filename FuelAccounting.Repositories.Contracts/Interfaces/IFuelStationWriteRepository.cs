using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="FuelStation"/>
    /// </summary>
    public interface IFuelStationWriteRepository : IRepositoryWriter<FuelStation>
    {
    }
}
