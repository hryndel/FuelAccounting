using FluentValidation;
using FuelAccounting.API.ModelsRequest.Fuel;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.Fuel
{
    /// <summary>
    /// Валидатор класса <see cref="CreateFuelRequest"/>
    /// </summary>
    public class CreateFuelRequestValidator : AbstractValidator<CreateFuelRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="CreateFuelRequestValidator"/>
        /// </summary>
        public CreateFuelRequestValidator(ISupplierReadRepository supplierReadRepository)
        {
            RuleFor(fuel => fuel.FuelType)
                .NotNull().WithMessage("Тип не должен быть null.")
                .NotEmpty().WithMessage("Тип не должен быть пустым.");

            RuleFor(fuel => fuel.Price)
                .NotNull().WithMessage("Цена не должна быть null.")
                .NotEmpty().WithMessage("Цена не должена быть пустой."); ;

            RuleFor(fuel => fuel.SupplierId)
                .NotNull().WithMessage("Поставщик не должен быть null.")
                .NotEmpty().WithMessage("Поставщик не должен быть пустым.")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var supplierExists = await supplierReadRepository.AnyByIdAsync(id, CancellationToken);
                    return supplierExists;
                })
                .WithMessage("Такого поставщика не существует!");

            RuleFor(fuel => fuel.Count)
                .NotNull().WithMessage("Количество не должно быть null.")
                .NotEmpty().WithMessage("Количество не должно быть пустым.");
        }
    }
}
