using FuelAccounting.Context.Contracts.Enums;

namespace FuelAccounting.Context.Contracts.Models
{
    /// <summary>
    /// Сущность топлива
    /// </summary>
    public class Fuel : BaseAuditEntity
    {
        /// <summary>
        /// Тип
        /// </summary>
        public FuelTypes FuelType { get; set; } = FuelTypes.Petrol92;

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Идентификатор <inheritdoc cref="Supplier"/>
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Поставщик
        /// </summary>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// Коллекция для связи один ко многим по вторичному ключу <see cref="FuelAccountingItem"/>
        /// </summary>
        public ICollection<FuelAccountingItem> FuelAccountingItem { get; set; }
    }
}
