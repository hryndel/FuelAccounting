using FuelAccounting.API.Infrastructures.Exceptions;
using FuelAccounting.Services.Contracts.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FuelAccounting.API.Infrastructures
{
    /// <summary>
    /// Фильтр для обработки ошибок раздела администрирования
    /// </summary>
    public class FuelAccountingExceptionFiltr : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception as FuelAccountingException;
            if (exception == null)
            {
                return;
            }

            switch (exception)
            {
                case FuelAccountingValidationException ex:
                    SetDataToContext(
                        new ConflictObjectResult(new ApiValidationExceptionDetail
                        {
                            Errors = ex.Errors,
                        }),
                        context);
                    break;

                case FuelAccountingInvalidOperationException ex:
                    SetDataToContext(
                        new BadRequestObjectResult(new ApiExceptionDetail { Message = ex.Message, })
                        {
                            StatusCode = StatusCodes.Status406NotAcceptable,
                        },
                        context);
                    break;

                case FuelAccountingNotFoundException ex:
                    SetDataToContext(new NotFoundObjectResult(new ApiExceptionDetail
                    {
                        Message = ex.Message,
                    }), context);
                    break;

                default:
                    SetDataToContext(new BadRequestObjectResult(new ApiExceptionDetail
                    {
                        Message = exception.Message,
                    }), context);
                    break;
            }
        }

        /// <summary>
        /// Определяет контекст ответа
        /// </summary>
        static protected void SetDataToContext(ObjectResult data, ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = data.StatusCode ?? StatusCodes.Status400BadRequest;
            context.Result = data;
        }
    }
}
