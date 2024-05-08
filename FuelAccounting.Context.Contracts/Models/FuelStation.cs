namespace FuelAccounting.Context.Contracts.Models
{
    /// <summary>
    /// Сущность АЗС
    /// </summary>
    public class FuelStation : BaseAuditEntity
    {
        /// <summary>
        /// Название АЗС
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description {  get; set; }

        /// <summary>
        /// Коллекция для связи один ко многим по вторичному ключу <see cref="FuelAccountingItem"/>
        /// </summary>
        public ICollection<FuelAccountingItem> FuelAccountingItem { get; set; }
    }
}
