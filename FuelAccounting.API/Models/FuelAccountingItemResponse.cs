namespace FuelAccounting.API.Models
{
    /// <summary>
    /// Модель ответа сущности накладной
    /// </summary>
    public class FuelAccountingItemResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ФИО водителя
        /// </summary>
        public string Driver { get; set; } = string.Empty;

        /// <summary>
        /// Название грузовика + номер
        /// </summary>
        public string Truck { get; set; } = string.Empty;

        /// <summary>
        /// Название полуприцепа + номер
        /// </summary>
        public string Trailer { get; set; } = string.Empty;

        /// <summary>
        /// Название топлива + поставщик
        /// </summary>
        public string Fuel { get; set; } = string.Empty;

        /// <summary>
        /// Количество топлива
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// Название АЗС
        /// </summary>
        public string FuelStation { get; set; } = string.Empty;

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTimeOffset EndDate { get; set; }
    }
}
