using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="Trailer"/>
    /// </summary>
    public interface ITrailerReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Trailer"/>
        /// </summary>
        Task<IReadOnlyCollection<Trailer>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Trailer"/> по идентификатору
        /// </summary>
        Task<Trailer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Trailer"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Trailer>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Trailer"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
