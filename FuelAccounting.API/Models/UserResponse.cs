namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности пользователя
    /// </summary>
    public class UserResponse
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
        /// Почта
        /// </summary>
        public string Mail { get; set; } = string.Empty;

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Тип
        /// </summary>
        public string UserType { get; set; } = string.Empty;
    }
}
