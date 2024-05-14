using FuelAccounting.Services.Contracts.Models;

namespace FuelAccounting.Services.Contracts.RequestModels
{
    /// <summary>
    /// Модель запроса накладной
    /// </summary>
    public class FuelAccountingItemRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="DriverModel"/>
        /// </summary>
        public Guid DriverId { get; set; }

        /// <summary>
        /// <inheritdoc cref="TruckModel"/>
        /// </summary>
        public Guid TruckId { get; set; }

        /// <summary>
        /// <inheritdoc cref="TrailerModel"/>
        /// </summary>
        public Guid TrailerId { get; set; }

        /// <summary>
        /// <inheritdoc cref="FuelModel"/>
        /// </summary>
        public Guid FuelId { get; set; }

        /// <summary>
        /// Количество топлива
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// <inheritdoc cref="FuelStationModel"/>
        /// </summary>
        public Guid FuelStationId { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTimeOffset EndDate { get; set; }
    }
}
