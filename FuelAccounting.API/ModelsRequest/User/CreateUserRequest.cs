using FuelAccounting.API.Models.Enums;

namespace FuelAccounting.API.ModelsRequest.User
{
    /// <summary>
    /// Модель запроса создания пользователя
    /// </summary>
    public class CreateUserRequest
    {
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
        public UserTypesResponse UserType { get; set; } = UserTypesResponse.Employee;
    }
}
