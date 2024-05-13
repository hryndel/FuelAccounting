using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="Supplier"/>
    /// </summary>
    public interface ISupplierReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Supplier"/>
        /// </summary>
        Task<IReadOnlyCollection<Supplier>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Supplier"/> по идентификатору
        /// </summary>
        Task<Supplier?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Supplier"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Supplier>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Supplier"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
