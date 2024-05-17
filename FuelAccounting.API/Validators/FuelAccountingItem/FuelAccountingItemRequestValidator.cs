using FluentValidation;
using FuelAccounting.API.ModelsRequest.FuelAccountingItem;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.FuelAccountingItem
{
    /// <summary>
    /// Валидатор класса <see cref="FuelAccountingItemRequest"/>
    /// </summary>
    public class FuelAccountingItemRequestValidator : AbstractValidator<FuelAccountingItemRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="FuelAccountingItemRequestValidator"/>
        /// </summary>
        public FuelAccountingItemRequestValidator(IDriverReadRepository driverReadRepository,
            ITruckReadRepository truckReadRepository,
            ITrailerReadRepository trailerReadRepository,
            IFuelReadRepository fuelReadRepository,
            IFuelStationReadRepository fuelStationReadRepository)
        {
            RuleFor(fuelAccountingItem => fuelAccountingItem.Id)
                .NotNull().WithMessage("Id не должно быть null")
                .NotEmpty().WithMessage("Id не должно быть пустым");

            RuleFor(fuelAccountingItem => fuelAccountingItem.DriverId)
                .NotNull().WithMessage("Водитель не должен быть null.")
                .NotEmpty().WithMessage("Водитель не должен быть пустым.")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var driverExists = await driverReadRepository.AnyByIdAsync(id, CancellationToken);
                    return driverExists;
                })
                .WithMessage("Такого водителя не существует.");

            RuleFor(fuelAccountingItem => fuelAccountingItem.TruckId)
                .NotNull().WithMessage("Грузовик не должен быть null.")
                .NotEmpty().WithMessage("Грузовик не должен быть пустым.")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var truckExists = await truckReadRepository.AnyByIdAsync(id, CancellationToken);
                    return truckExists;
                })
                .WithMessage("Такого грузовика не существует.");

            RuleFor(fuelAccountingItem => fuelAccountingItem.TrailerId)
                .NotNull().WithMessage("Полуприцеп не должен быть null.")
                .NotEmpty().WithMessage("Полуприцеп не должен быть пустым.")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var trailerExists = await trailerReadRepository.AnyByIdAsync(id, CancellationToken);
                    return trailerExists;
                })
                .WithMessage("Такого полуприцепа не существует.");

            RuleFor(fuelAccountingItem => fuelAccountingItem.FuelId)
                .NotNull().WithMessage("Топливо не должно быть null.")
                .NotEmpty().WithMessage("Топливо не должно быть пустым.")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var fuelExists = await fuelReadRepository.AnyByIdAsync(id, CancellationToken);
                    return fuelExists;
                })
                .WithMessage("Такого топлива не существует.");

            RuleFor(fuelAccountingItem => fuelAccountingItem.Count)
                .NotNull().WithMessage("Количество не должно быть null.")
                .NotEmpty().WithMessage("Количество не должно быть пустым.");

            RuleFor(fuelAccountingItem => fuelAccountingItem.FuelStationId)
                .NotNull().WithMessage("АЗС не должна быть null.")
                .NotEmpty().WithMessage("АЗС не должна быть пустым.")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var fuelStationExists = await fuelStationReadRepository.AnyByIdAsync(id, CancellationToken);
                    return fuelStationExists;
                })
                .WithMessage("Такой АЗС не существует.");

            RuleFor(fuelAccountingItem => fuelAccountingItem.StartDate)
                .NotNull().WithMessage("Дата отправки не должна быть null.")
                .NotEmpty().WithMessage("Дата отправки не должна быть пустым.");

            RuleFor(fuelAccountingItem => fuelAccountingItem.EndDate)
                .NotNull().WithMessage("Дата прибытия не должна быть null.")
                .NotEmpty().WithMessage("Дата прибытия не должна быть пустым.");
        }
    }
}
