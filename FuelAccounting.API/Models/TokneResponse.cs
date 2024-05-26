using FuelAccounting.API.Models.Enums;

namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа токена
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Тип
        /// </summary>
        public UserTypesResponse UserType { get; set; } = UserTypesResponse.Employee;

        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}
