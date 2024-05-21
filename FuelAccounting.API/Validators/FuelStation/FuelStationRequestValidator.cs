using FluentValidation;
using FuelAccounting.API.ModelsRequest.FuelStation;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.FuelStation
{
    /// <summary>
    /// Валидатор класса <see cref="FuelStationRequest"/>
    /// </summary>
    public class FuelStationRequestValidator : AbstractValidator<FuelStationRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="FuelStationRequestValidator"/>
        /// </summary>
        public FuelStationRequestValidator(IFuelStationReadRepository fuelStationReadRepository)
        {
            RuleFor(fuelStation => fuelStation.Id)
                .NotNull().WithMessage("Id не должно быть null")
                .NotEmpty().WithMessage("Id не должно быть пустым");

            RuleFor(fuelStation => fuelStation.Name)
                .NotNull().WithMessage("Название не должно быть null.")
                .NotEmpty().WithMessage("Название не должно быть пустым.")
                .Length(2, 50).WithMessage("Название не должно быть меньше 2 и больше 50 символов.");

            RuleFor(fuelStation => fuelStation.Address)
                .NotNull().WithMessage("Адрес не должен быть null.")
                .NotEmpty().WithMessage("Адрес не должен быть пустым.")
                .Length(2, 100).WithMessage("Адрес не должно быть меньше 2 и больше 100 символов.")
                .Must((fuelStation, _) =>
                {
                    var addressExists = fuelStationReadRepository.AnyByAddressAndId(fuelStation.Address, fuelStation.Id);
                    return !addressExists;
                }).WithMessage("Такой адрес уже существует.");

            RuleFor(fuelStation => fuelStation.Description)
                .NotEmpty().WithMessage("Описание не должно быть пустым.")
                .MaximumLength(100).WithMessage("Описание не должно быть больше 100 символов.");
        }
    }
}
