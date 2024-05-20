namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности поставщика
    /// </summary>
    public class SupplierResponse
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
        public string Inn { get; set; } = string.Empty;

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
