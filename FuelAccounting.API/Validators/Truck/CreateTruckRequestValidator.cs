using FluentValidation;
using FuelAccounting.API.ModelsRequest.Truck;

namespace FuelAccounting.API.Validators.Truck
{
    /// <summary>
    /// Валидатор класса <see cref="CreateTruckRequest"/>
    /// </summary>
    public class CreateTruckRequestValidator : AbstractValidator<CreateTruckRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="CreateTruckRequestValidator"/>
        /// </summary>
        public CreateTruckRequestValidator()
        {
            RuleFor(truck => truck.Name)
                .NotNull().WithMessage("Название не должно быть null.")
                .NotEmpty().WithMessage("Название не должно быть пустым.")
                .Length(2, 100).WithMessage("Название не должно быть меньше 2 и больше 100 символов.");

            RuleFor(truck => truck.Number)
                .NotNull().WithMessage("Номер не должен быть null.")
                .NotEmpty().WithMessage("Номер не должен быть пустым.")
                .Length(2, 10).WithMessage("Номер не должен быть меньше 2 и больше 10 символов.");

            RuleFor(truck => truck.Vin)
                .NotNull().WithMessage("Vin не должен быть null.")
                .NotEmpty().WithMessage("Vin не должен быть пустым.")
                .Length(2, 20).WithMessage("Vin не должен быть меньше 2 и больше 20 символов.");
        }
    }
}
