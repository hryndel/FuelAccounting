namespace FuelAccounting.Services.Contracts.Models
{
    /// <summary>
    /// Модель накладной
    /// </summary>
    public class FuelAccountingItemModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="DriverModel"/>
        /// </summary>
        public DriverModel Driver { get; set; }

        /// <summary>
        /// <inheritdoc cref="TruckModel"/>
        /// </summary>
        public TruckModel Truck { get; set; }

        /// <summary>
        /// <inheritdoc cref="TrailerModel"/>
        /// </summary>
        public TrailerModel Trailer { get; set; }

        /// <summary>
        /// <inheritdoc cref="FuelModel"/>
        /// </summary>
        public FuelModel Fuel { get; set; }

        /// <summary>
        /// <inheritdoc cref="FuelStationModel"/>
        /// </summary>
        public FuelStationModel FuelStation { get; set; }

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
