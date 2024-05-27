using FuelAccounting.API.Models.Enums;

namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности топлива
    /// </summary>
    public class FuelResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public FuelTypesResponse FuelType { get; set; } = FuelTypesResponse.Petrol92;

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// <see cref="SupplierResponse"/>
        /// </summary>
        public SupplierResponse? Supplier { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Count { get; set; }
    }
}
