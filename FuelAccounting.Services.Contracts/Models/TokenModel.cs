using FuelAccounting.Services.Contracts.Models.Enums;

namespace FuelAccounting.Services.Contracts.Models
{
    /// <summary>
    /// Модель токена
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Тип
        /// </summary>
        public UserTypesModel UserType { get; set; } = UserTypesModel.Employee;

        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}