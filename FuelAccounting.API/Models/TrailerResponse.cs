namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности полуприцепа
    /// </summary>
    public class TrailerResponse
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
        /// Государственный номер
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Вместимость
        /// </summary>
        public double Capacity { get; set; }
    }
}
