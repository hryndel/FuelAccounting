using System.ComponentModel;

namespace FuelAccounting.API.Models.Enums
{
    /// <summary>
    /// Типы топлива
    /// </summary>
    public enum FuelTypesResponse
    {
        /// <summary>
        /// Бензин 92 пробы
        /// </summary>
        [Description("Бензин 92 пробы")]
        Petrol92,

        /// <summary>
        /// Бензин 95 пробы
        /// </summary>
        [Description("Бензин 95 пробы")]
        Petrol95,

        /// <summary>
        /// Бензин 98 пробы
        /// </summary>
        [Description("Бензин 98 пробы")]
        Petrol98,

        /// <summary>
        /// Бензин 100 пробы
        /// </summary>
        [Description("Бензин 100 пробы")]
        Petrol100,

        /// <summary>
        /// Дизель
        /// </summary>
        [Description("Дизель")]
        Disel
    }
}
