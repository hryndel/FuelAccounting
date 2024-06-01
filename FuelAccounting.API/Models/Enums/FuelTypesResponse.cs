using System.ComponentModel;

namespace FuelAccounting.API.Models.Enums
{
    /// <summary>
    /// Типы топлива
    /// </summary>
    public enum FuelTypesResponse
    {
        /// <summary>
        /// АИ-92
        /// </summary>
        [Description("АИ-92")]
        Petrol92,

        /// <summary>
        /// АИ-95
        /// </summary>
        [Description("АИ-95")]
        Petrol95,

        /// <summary>
        /// АИ-98
        /// </summary>
        [Description("АИ-98")]
        Petrol98,

        /// <summary>
        /// АИ-100
        /// </summary>
        [Description("АИ-100")]
        Petrol100,

        /// <summary>
        /// Дизель
        /// </summary>
        [Description("Дизель")]
        Disel
    }
}
