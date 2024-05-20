namespace FuelAccounting.API.ModelsRequest.Fuel
{
    /// <summary>
    /// Модель запроса редактирования топлива
    /// </summary>
    public class FuelRequest : CreateFuelRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
