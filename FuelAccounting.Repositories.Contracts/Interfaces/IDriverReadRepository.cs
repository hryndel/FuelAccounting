using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="Driver"/>
    /// </summary>
    public interface IDriverReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Driver"/>
        /// </summary>
        Task<IReadOnlyCollection<Driver>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Driver"/> по идентификатору
        /// </summary>
        Task<Driver?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Driver"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Driver>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Driver"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Driver"/> по указанному ВУ
        /// </summary>
        Task<bool> AnyByDriversLicenseAsync(string driversLicense, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Driver"/> по указанному ВУ с Id
        /// </summary>
        bool AnyByDriversLicenseAndId(string driversLicense, Guid id);

        /// <summary>
        /// Проверка есть ли <see cref="Driver"/> по указанному телефону
        /// </summary>
        Task<bool> AnyByPhoneAsync(string phone, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Driver"/> по указанному телефону с Id
        /// </summary>
        bool AnyByPhoneAndId(string phone, Guid id);
    }
}
