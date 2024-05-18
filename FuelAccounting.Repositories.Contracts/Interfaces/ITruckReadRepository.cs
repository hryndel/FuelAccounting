using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="Truck"/>
    /// </summary>
    public interface ITruckReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Truck"/>
        /// </summary>
        Task<IReadOnlyCollection<Truck>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Truck"/> по идентификатору
        /// </summary>
        Task<Truck?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Truck"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Truck>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Truck"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Truck"/> по указанному номеру
        /// </summary>
        Task<bool> AnyByNumberAsync(string number, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Truck"/> по указанному номеру с Id
        /// </summary>
        bool AnyByNumberAndId(string number, Guid id);

        /// <summary>
        /// Проверка есть ли <see cref="Truck"/> по указанному Vin
        /// </summary>
        Task<bool> AnyByVinAsync(string vin, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Truck"/> по указанному Vin с Id
        /// </summary>
        bool AnyByVinAndId(string vin, Guid id);
    }
}
