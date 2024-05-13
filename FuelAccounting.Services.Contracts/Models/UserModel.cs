using FuelAccounting.Services.Contracts.Models.Enums;

namespace FuelAccounting.Services.Contracts.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class UserModel
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
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Тип
        /// </summary>
        public UserTypesModel UserType { get; set; }
    }
}
