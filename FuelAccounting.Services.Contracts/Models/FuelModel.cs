using FuelAccounting.Services.Contracts.Models.Enums;

namespace FuelAccounting.Services.Contracts.Models
{
    /// <summary>
    /// Модель топлива
    /// </summary>
    public class FuelModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public FuelTypesModel FuelType { get; set; } 

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// <inheritdoc cref="SupplierModel"/>
        /// </summary>
        public SupplierModel Supplier { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Count { get; set; }
    }
}
