namespace FuelAccounting.Context.Contracts.Models
{
    /// <summary>
    /// Сущность грузовика
    /// </summary>
    public class Truck : BaseAuditEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Государсвтенный номер
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// VIN номер
        /// </summary>
        public string Vin { get; set; } = string.Empty;

        /// <summary>
        /// Коллекция для связи один ко многим по вторичному ключу <see cref="FuelAccountingItem"/>
        /// </summary>
        public ICollection<FuelAccountingItem> FuelAccountingItem { get; set; }
    }
}
