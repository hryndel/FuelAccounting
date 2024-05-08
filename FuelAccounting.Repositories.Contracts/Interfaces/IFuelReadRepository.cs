using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="Fuel"/>
    /// </summary>
    public interface IFuelReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Fuel"/>
        /// </summary>
        Task<IReadOnlyCollection<Fuel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Fuel"/> по идентификатору
        /// </summary>
        Task<Fuel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Fuel"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Fuel>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Fuel"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
