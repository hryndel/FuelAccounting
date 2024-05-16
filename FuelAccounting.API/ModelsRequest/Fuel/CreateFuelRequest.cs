using FuelAccounting.API.Models.Enums;
using FuelAccounting.Services.Contracts.Models;

namespace FuelAccounting.API.ModelsRequest.Fuel
{
    /// <summary>
    /// Модель запроса создания топлива
    /// </summary>
    public class CreateFuelRequest
    {
        /// <summary>
        /// Тип
        /// </summary>
        public FuelTypesResponse FuelType { get; set; } = FuelTypesResponse.Petrol92;

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Идентификатор <inheritdoc cref="SupplierModel"/>
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Count { get; set; }
    }
}
