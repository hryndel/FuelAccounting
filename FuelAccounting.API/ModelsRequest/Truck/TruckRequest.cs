namespace FuelAccounting.API.ModelsRequest.Truck
{
    /// <summary>
    /// Модель запроса редактирования грузовика
    /// </summary>
    public class TruckRequest : CreateTruckRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
