﻿namespace FuelAccounting.API.ModelsRequest.Supplier
{
    /// <summary>
    /// Модель запроса создания поставщика
    /// </summary>
    public class CreateSupplierRequest
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; } = string.Empty;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
    }
}
