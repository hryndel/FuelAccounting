namespace FuelAccounting.Context.Contracts.Models
{
    /// <summary>
    /// Элемент накладной
    /// </summary>
    public class FuelAccountingItem : BaseAuditEntity
    {
        /// <summary>
        /// Индентификатор <inheritdoc cref="Driver"/>
        /// </summary>
        public Guid DriverId { get; set; }

        /// <summary>
        /// Связь один ко многим
        /// </summary>
        public Driver Driver { get; set; }

        /// <summary>
        /// Индентификатор <inheritdoc cref="Truck"/>
        /// </summary>
        public Guid TruckId { get; set; }

        /// <summary>
        /// Связь один ко многим
        /// </summary>
        public Truck Truck { get; set; }

        /// <summary>
        /// Индентификатор <inheritdoc cref="Trailer"/>
        /// </summary>
        public Guid TrailerId { get; set; }

        /// <summary>
        /// Связь один ко многим
        /// </summary>
        public Trailer Trailer { get; set; }

        /// <summary>
        /// Идентификатор <inheritdoc cref="Fuel"/>
        /// </summary>
        public Guid FuelId { get; set; }

        /// <summary>
        /// Связь один ко многим
        /// </summary>
        public Fuel Fuel { get; set; }

        /// <summary>
        /// Количество топлива
        /// </summary>
        public double Count { get; set; }
        
        /// <summary>
        /// Идентификатор <inheritdoc cref="FuelStation"/>
        /// </summary>
        public Guid FuelStationId { get; set; }
        
        /// <summary>
        /// Связь один ко многим
        /// </summary>
        public FuelStation FuelStation { get; set; }

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
