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

        /// <summary>
        /// Проверка есть ли <see cref="Supplier"/> по указанному ИНН
        /// </summary>
        Task<bool> AnyByInnAsync(int inn, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Supplier"/> по указанному ИНН с Id
        /// </summary>
        bool AnyByInnAndId(int inn, Guid id);

        /// <summary>
        /// Проверка есть ли <see cref="Supplier"/> по указанному номеру
        /// </summary>
        Task<bool> AnyByPhoneAsync(string phone, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Supplier"/> по указанному номеру с Id
        /// </summary>
        bool AnyByPhoneAndId(string phone, Guid id);
    }
}
