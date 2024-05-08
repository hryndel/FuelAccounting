﻿using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="User"/>
    /// </summary>
    public interface IUserReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="User"/>
        /// </summary>
        Task<IReadOnlyCollection<User>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="User"/> по идентификатору
        /// </summary>
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="User"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, User>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="User"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
