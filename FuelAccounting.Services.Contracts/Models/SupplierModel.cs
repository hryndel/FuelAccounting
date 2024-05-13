namespace FuelAccounting.Services.Contracts.Models
{
    /// <summary>
    /// Модель поставщика
    /// </summary>
    public class SupplierModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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
    }
}
