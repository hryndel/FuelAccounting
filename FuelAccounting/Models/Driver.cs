namespace FuelAccounting.Context.Contracts.Models
{
    /// <summary>
    /// Сущность водителя
    /// </summary>
    public class Driver : BaseAuditEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Водительское удостоверение
        /// </summary>
        public string DriversLicense {  get; set; } = string.Empty;

        /// <summary>
        /// Коллекция для связи один ко многим по вторичному ключу <see cref="FuelAccountingItem"/>
        /// </summary>
        public ICollection<FuelAccountingItem> FuelAccountingItem { get; set; }
    }
}
