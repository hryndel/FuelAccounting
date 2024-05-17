namespace FuelAccounting.API.ModelsRequest.Truck
{
    /// <summary>
    /// Модель запроса создания грузовика
    /// </summary>
    public class CreateTruckRequest
    {
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
