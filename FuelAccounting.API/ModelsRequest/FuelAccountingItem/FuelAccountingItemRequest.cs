namespace FuelAccounting.API.ModelsRequest.FuelAccountingItem
{
    /// <summary>
    /// Модель запроса редактирования накладной
    /// </summary>
    public class FuelAccountingItemRequest : CreateFuelAccountingItemRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
