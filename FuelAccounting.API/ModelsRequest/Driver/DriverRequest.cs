namespace FuelAccounting.API.ModelsRequest.Driver
{
    /// <summary>
    /// Модель запроса редактирования водителя
    /// </summary>
    public class DriverRequest : CreateDriverRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
