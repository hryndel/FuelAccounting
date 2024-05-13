﻿using FuelAccounting.Context.Contracts.Models;

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
    }
}