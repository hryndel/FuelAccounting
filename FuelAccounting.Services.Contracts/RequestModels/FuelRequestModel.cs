using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.Models.Enums;

namespace FuelAccounting.Services.Contracts.RequestModels
{
    /// <summary>
    /// Модель запроса топлива
    /// </summary>
    public class FuelRequestModel
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
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Count { get; set; }
    }
}
