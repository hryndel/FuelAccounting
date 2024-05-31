using FluentValidation;
using FuelAccounting.API.ModelsRequest.Trailer;
using FuelAccounting.Repositories.Contracts.Interfaces;

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
        public CreateTrailerRequestValidator(ITrailerReadRepository trailerReadRepository)
        {
            RuleFor(trailer => trailer.Name)
                .NotNull().WithMessage("Название не должно быть null.")
                .NotEmpty().WithMessage("Название не должно быть пустым.")
                .Length(2, 100).WithMessage("Название не должно быть меньше 2 и больше 100 символов.");

            RuleFor(trailer => trailer.Number)
                .NotNull().WithMessage("Номер не должен быть null.")
                .NotEmpty().WithMessage("Номер не должен быть пустым.")
                .Length(2, 10).WithMessage("Номер не должен быть меньше 2 и больше 10 символов.")
                .Matches(@"^[АВЕКМНОРСТУХ]{2}\d{4}(?<!0000)\d{2,3}(?<!000)$").WithMessage("Номер должен соответствовать госту (XX0000000).")
                .MustAsync(async (number, CancellationToken) =>
                {
                    var numberExists = await trailerReadRepository.AnyByNumberAsync(number, CancellationToken);
                    return !numberExists;
                }).WithMessage("Такой номер уже существует.");

            RuleFor(trailer => trailer.Capacity)
                .NotNull().WithMessage("Вместимость не должна быть null.")
                .NotEmpty().WithMessage("Вместимость не должена быть пустой.");
        }
    }
}
