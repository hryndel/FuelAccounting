namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности топлива
    /// </summary>
    public class FuelResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public string FuelType { get; set; } = string.Empty;

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Поставщик
        /// </summary>
        public string Supplier { get; set; } = string.Empty;

        /// <summary>
        /// Количество
        /// </summary>
        public double Count { get; set; }
    }
}
