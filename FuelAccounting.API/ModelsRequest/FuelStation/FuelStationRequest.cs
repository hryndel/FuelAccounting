namespace FuelAccounting.API.ModelsRequest.FuelStation
{
    /// <summary>
    /// Модель запроса редактирования АЗС
    /// </summary>
    public class FuelStationRequest : CreateFuelStationRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
