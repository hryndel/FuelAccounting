namespace FuelAccounting.Context.Contracts.Models
{
    /// <summary>
    /// Сущеость поставщика
    /// </summary>
    public class Supplier : BaseAuditEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// ИНН
        /// </summary>
        public int Inn { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Коллекция для связи один ко многим по вторичному ключу <see cref="Fuel"/>
        /// </summary>
        public ICollection<Fuel> Fuel { get; set; }
    }
}
