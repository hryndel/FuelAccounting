using FuelAccounting.Services.Contracts.Models;

namespace FuelAccounting.API.ModelsRequest.FuelAccountingItem
{
    /// <summary>
    /// Модель запроса создания накладной
    /// </summary>
    public class CreateFuelAccountingItemRequest
    {
        /// <summary>
        /// Индентификатор <inheritdoc cref="DriverModel"/>
        /// </summary>
        public Guid DriverId { get; set; }

        /// <summary>
        /// Индентификатор <inheritdoc cref="TruckModel"/>
        /// </summary>
        public Guid TruckId { get; set; }

        /// <summary>
        /// Индентификатор <inheritdoc cref="TrailerModel"/>
        /// </summary>
        public Guid TrailerId { get; set; }

        /// <summary>
        /// Идентификатор <inheritdoc cref="FuelModel"/>
        /// </summary>
        public Guid FuelId { get; set; }

        /// <summary>
        /// Количество топлива
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// Идентификатор <inheritdoc cref="FuelStationModel"/>
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
