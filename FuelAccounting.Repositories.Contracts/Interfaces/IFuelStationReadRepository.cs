using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="FuelStation"/>
    /// </summary>
    public interface IFuelStationReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="FuelStation"/>
        /// </summary>
        Task<IReadOnlyCollection<FuelStation>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="FuelStation"/> по идентификатору
        /// </summary>
        Task<FuelStation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="FuelStation"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, FuelStation>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="FuelStation"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="FuelStation"/> по указанному адресу
        /// </summary>
        Task<bool> AnyByAddressAsync(string address, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="FuelStation"/> по указанному адресу с Id
        /// </summary>
        bool AnyByAddressAndId(string address, Guid id);
    }
}
