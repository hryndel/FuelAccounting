namespace FuelAccounting.Services.Contracts.RequestModels
{
    /// <summary>
    /// Модель запроса грузовика
    /// </summary>
    public class TruckRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Государсвтенный номер
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// VIN номер
        /// </summary>
        public string Vin { get; set; } = string.Empty;
    }
}
