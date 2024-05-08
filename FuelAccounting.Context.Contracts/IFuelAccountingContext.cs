using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Context.Contracts
{
    /// <summary>
    /// Контекст работы с сущностями
    /// </summary>
    public interface IFuelAccountingContext
    {
        /// <summary>Список <inheritdoc cref="Driver"/></summary>
        DbSet<Driver> Drivers { get; }

        /// <summary>Список <inheritdoc cref="Fuel"/></summary>
        DbSet<Fuel> Fuels { get; }

        /// <summary>Список <inheritdoc cref="FuelAccountingItem"/></summary>
        DbSet<FuelAccountingItem> FuelAccountingItems { get; }

        /// <summary>Список <inheritdoc cref="FuelStation"/></summary>
        DbSet<FuelStation> FuelStations { get; }

        /// <summary>Список <inheritdoc cref="Supplier"/></summary>
        DbSet<Supplier> Suppliers { get; }

        /// <summary>Список <inheritdoc cref="Trailer"/></summary>
        DbSet<Trailer> Trailers { get; }

        /// <summary>Список <inheritdoc cref="Truck"/></summary>
        DbSet<Truck> Trucks { get; }

        /// <summary>Список <inheritdoc cref="User"/></summary>
        DbSet<User> Users { get; }
    }
}
