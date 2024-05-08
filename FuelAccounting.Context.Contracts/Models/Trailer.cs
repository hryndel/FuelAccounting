namespace FuelAccounting.Context.Contracts.Models
{
    /// <summary>
    /// Сущность полуприцепа
    /// </summary>
    public class Trailer : BaseAuditEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Государственный номер
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Вместимость
        /// </summary>
        public double Capacity { get; set; }

        /// <summary>
        /// Коллекция для связи один ко многим по вторичному ключу <see cref="FuelAccountingItem"/>
        /// </summary>
        public ICollection<FuelAccountingItem> FuelAccountingItem { get; set; }
    }
}
