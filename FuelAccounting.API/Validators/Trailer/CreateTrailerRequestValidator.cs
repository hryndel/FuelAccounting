using FluentValidation;
using FuelAccounting.API.ModelsRequest.Trailer;

namespace FuelAccounting.API.Validators.Trailer
{
    /// <summary>
    /// Валидатор класса <see cref="CreateTrailerRequest"/>
    /// </summary>
    public class CreateTrailerRequestValidator : AbstractValidator<CreateTrailerRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="CreateTrailerRequestValidator"/>
        /// </summary>
        public CreateTrailerRequestValidator()
        {
            RuleFor(trailer => trailer.Name)
                .NotNull().WithMessage("Название не должно быть null.")
                .NotEmpty().WithMessage("Название не должно быть пустым.")
                .Length(2, 100).WithMessage("Название не должно быть меньше 2 и больше 100 символов.");

            RuleFor(trailer => trailer.Number)
                .NotNull().WithMessage("Номер не должен быть null.")
                .NotEmpty().WithMessage("Номер не должен быть пустым.")
                .Length(2, 10).WithMessage("Номер не должен быть меньше 2 и больше 10 символов.");

            RuleFor(trailer => trailer.Capacity)
                .NotNull().WithMessage("Вместимость не должна быть null.")
                .NotEmpty().WithMessage("Вместимость не должена быть пустой.");
        }
    }
}
