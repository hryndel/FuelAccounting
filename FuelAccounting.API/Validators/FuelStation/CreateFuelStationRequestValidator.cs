using FluentValidation;
using FuelAccounting.API.ModelsRequest.FuelStation;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.FuelStation
{
    /// <summary>
    /// Валидатор класса <see cref="CreateFuelStationRequest"/>
    /// </summary>
    public class CreateFuelStationRequestValidator : AbstractValidator<CreateFuelStationRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="CreateFuelStationRequestValidator"/>
        /// </summary>
        public CreateFuelStationRequestValidator(IFuelStationReadRepository fuelStationReadRepository)
        {
            RuleFor(fuelStation => fuelStation.Name)
                .NotNull().WithMessage("Название не должно быть null.")
                .NotEmpty().WithMessage("Название не должно быть пустым.")
                .Length(2, 50).WithMessage("Название не должно быть меньше 2 и больше 50 символов.");

            RuleFor(fuelStation => fuelStation.Address)
                .NotNull().WithMessage("Адрес не должен быть null.")
                .NotEmpty().WithMessage("Адрес не должен быть пустым.")
                .Length(2, 100).WithMessage("Адрес не должно быть меньше 2 и больше 100 символов.")
                .MustAsync(async (address, CancellationToken) =>
                {
                    var addressExists = await fuelStationReadRepository.AnyByAddressAsync(address, CancellationToken);
                    return !addressExists;
                }).WithMessage("Такой адрес уже существует.");

            RuleFor(fuelStation => fuelStation.Description)
                .MaximumLength(100).WithMessage("Адрес не должен быть больше 100 символов.");
        }
    }
}