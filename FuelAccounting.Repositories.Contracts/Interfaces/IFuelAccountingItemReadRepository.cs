using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="FuelAccountingItem"/>
    /// </summary>
    public interface IFuelAccountingItemReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="FuelAccountingItem"/>
        /// </summary>
        Task<IReadOnlyCollection<FuelAccountingItem>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="FuelAccountingItem"/> по идентификатору
        /// </summary>
        Task<FuelAccountingItem?> GetByIdAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Получить последний <see cref="FuelAccountingItem"/> по id водителя
        /// </summary>
        Task<FuelAccountingItem?> GetByDriverIdAsync(Guid driverId, CancellationToken cancellationToken);

        /// <summary>
        /// Получить последний <see cref="FuelAccountingItem"/> по id полуприцепа
        /// </summary>
        Task<FuelAccountingItem?> GetByTrailerIdAsync(Guid trailerId, CancellationToken cancellationToken);

        /// <summary>
        /// Получить последний <see cref="FuelAccountingItem"/> по id грузовика
        /// </summary>
        Task<FuelAccountingItem?> GetByTruckIdAsync(Guid truckId, CancellationToken cancellationToken);
    }
}
