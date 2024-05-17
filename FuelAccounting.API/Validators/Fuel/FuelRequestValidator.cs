using FluentValidation;
using FuelAccounting.API.ModelsRequest.Fuel;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.Fuel
{
    /// <summary>
    /// Валидатор класса <see cref="FuelRequest"/>
    /// </summary>
    public class FuelRequestValidator : AbstractValidator<FuelRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="FuelRequestValidator"/>
        /// </summary>
        public FuelRequestValidator(ISupplierReadRepository supplierReadRepository)
        {
            RuleFor(fuel => fuel.Id)
                .NotNull().WithMessage("Id не должно быть null")
                .NotEmpty().WithMessage("Id не должно быть пустым");

            RuleFor(fuel => fuel.FuelType)
                .NotNull().WithMessage("Тип не должен быть null.")
                .IsInEnum().WithMessage("Тип не существует.");

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
                .WithMessage("Такого поставщика не существует.");

            RuleFor(fuel => fuel.Count)
                .NotNull().WithMessage("Количество не должно быть null.")
                .NotEmpty().WithMessage("Количество не должно быть пустым.");
        }
    }
}
