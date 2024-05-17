namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности АЗС
    /// </summary>
    public class FuelStationResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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
        public string? Description { get; set; }
    }
}
