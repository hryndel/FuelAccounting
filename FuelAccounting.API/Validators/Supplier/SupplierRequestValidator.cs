using FluentValidation;
using FuelAccounting.API.ModelsRequest.Supplier;
using FuelAccounting.Repositories.Contracts.Interfaces;
using FuelAccounting.Repositories.Implementations;

namespace FuelAccounting.API.Validators.Supplier
{
    /// <summary>
    /// Валидатор класса <see cref="SupplierRequest"/>
    /// </summary>
    public class SupplierRequestValidator : AbstractValidator<SupplierRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="SupplierRequestValidator"/>
        /// </summary>
        public SupplierRequestValidator(ISupplierReadRepository supplierReadRepository)
        {
            RuleFor(supplier => supplier.Id)
                .NotNull().WithMessage("Id не должно быть null")
                .NotEmpty().WithMessage("Id не должно быть пустым");

            RuleFor(supplier => supplier.Name)
                .NotNull().WithMessage("Название не должно быть null.")
                .NotEmpty().WithMessage("Название не должно быть пустым.")
                .Length(2, 50).WithMessage("Название не должно быть меньше 2 и больше 50 символов.");

            RuleFor(supplier => supplier.Inn)
                .NotNull().WithMessage("ИНН не должно быть null.")
                .NotEmpty().WithMessage("ИНН не должно быть пустым.")
                .Must((supplier, _) =>
                {
                    var innExists = supplierReadRepository.AnyByInnAndId(supplier.Inn, supplier.Id);
                    return !innExists;
                }).WithMessage("Такой ИНН уже существует.");

            RuleFor(supplier => supplier.Phone)
                .NotNull().WithMessage("Номер телефона не должен быть null.")
                .NotEmpty().WithMessage("Номер телефона не должен быть пустым.")
                .Length(2, 20).WithMessage("Номер телефона не должен быть меньше 2 и больше 20 символов.")
                .Must((supplier, _) =>
                {
                    var phoneExists = supplierReadRepository.AnyByPhoneAndId(supplier.Phone, supplier.Id);
                    return !phoneExists;
                }).WithMessage("Такой номер уже существует.");

            RuleFor(supplier => supplier.Description)
                .MaximumLength(100).WithMessage("Описание не должно быть больше 100 символов.");
        }
    }
}
