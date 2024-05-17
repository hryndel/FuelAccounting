namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности водителя
    /// </summary>
    public class DriverResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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
        public string DriversLicense { get; set; } = string.Empty;
    }
}
