using FuelAccounting.Context.Contracts.Models;
using System.Diagnostics.CodeAnalysis;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий записи <see cref="Fuel"/>
    /// </summary>
    public interface IFuelWriteRepository : IRepositoryWriter<Fuel>
    {
        /// <summary>
        /// Изменить количество топлива <see cref="Fuel"/>
        /// </summary>
        void UpdateFuelCount([NotNull] Fuel item, double count);
    }
}
