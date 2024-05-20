namespace FuelAccounting.API.ModelsRequest.Supplier
{
    /// <summary>
    /// Модель запроса редактирования поставщика
    /// </summary>
    public class SupplierRequest : CreateSupplierRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
