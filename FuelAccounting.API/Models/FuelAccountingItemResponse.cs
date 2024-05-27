namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности накладной
    /// </summary>
    public class FuelAccountingItemResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <see cref="DriverResponse"/>
        /// </summary>
        public DriverResponse? Driver { get; set; }

        /// <summary>
        /// <see cref="TruckResponse"/>
        /// </summary>
        public TruckResponse? Truck { get; set; }

        /// <summary>
        /// <see cref="TrailerResponse"/>
        /// </summary>
        public TrailerResponse? Trailer { get; set; }

        /// <summary>
        /// <see cref="FuelResponse"/>
        /// </summary>
        public FuelResponse? Fuel { get; set; }

        /// <summary>
        /// Количество топлива
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// <see cref="FuelStationResponse"/>
        /// </summary>
        public FuelStationResponse? FuelStation { get; set; }

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
