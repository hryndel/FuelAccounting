namespace FuelAccounting.Services.Contracts.Models
{
    /// <summary>
    /// Модель водителя
    /// </summary>
    public class DriverModel
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
