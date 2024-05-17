using System.ComponentModel;

namespace FuelAccounting.API.Models.Enums
{
    /// <summary>
    /// Типы ролей пользователей
    /// </summary>
    public enum UserTypesResponse
    {
        /// <summary>
        /// Сотрудник
        /// </summary>
        [Description("Сотрудник")]
        Employee,

        /// <summary>
        /// Менеджер
        /// </summary>
        [Description("Менеджер")]
        Manager,

        /// <summary>
        /// Администратор
        /// </summary>
        [Description("Администратор")]
        Administrator
    }
}
