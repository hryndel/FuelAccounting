﻿using FuelAccounting.Shared;

namespace FuelAccounting.API.Infrastructures.Exceptions
{
    /// <summary>
    /// Информация об ошибках валидации работы API
    /// </summary>
    public class ApiValidationExceptionDetail
    {
        /// <summary>
        /// Ошибки валидации
        /// </summary>
        public IEnumerable<InvalidateItemModel> Errors { get; set; } = Array.Empty<InvalidateItemModel>();
    }
}
