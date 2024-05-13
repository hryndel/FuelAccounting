namespace FuelAccounting.Services.Contracts.Models
{
    /// <summary>
    /// Модель полуприцепа
    /// </summary>
    public class TrailerModel
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
