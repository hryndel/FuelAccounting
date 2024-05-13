namespace FuelAccounting.Services.Contracts.RequestModels
{
    /// <summary>
    /// Модель запроса полуприцепа
    /// </summary>
    public class TrailerRequestModel
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
