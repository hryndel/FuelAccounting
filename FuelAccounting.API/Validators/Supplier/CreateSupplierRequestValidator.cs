using FluentValidation;
using FuelAccounting.API.ModelsRequest.Supplier;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.Supplier
{
    /// <summary>
    /// Валидатор класса <see cref="CreateSupplierRequest"/>
    /// </summary>
    public class CreateSupplierRequestValidator : AbstractValidator<CreateSupplierRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="CreateSupplierRequestValidator"/>
        /// </summary>
        public CreateSupplierRequestValidator(ISupplierReadRepository supplierReadRepository)
        {
            RuleFor(supplier => supplier.Name)
                .NotNull().WithMessage("Название не должно быть null.")
                .NotEmpty().WithMessage("Название не должно быть пустым.")
                .Length(2, 50).WithMessage("Название не должно быть меньше 2 и больше 50 символов.");

            RuleFor(supplier => supplier.Inn)
                .NotNull().WithMessage("ИНН не должно быть null.")
                .NotEmpty().WithMessage("ИНН не должно быть пустым.")
                .Length(12, 20).WithMessage("Название не должно быть меньше 12 и больше 20 символов.")
                .MustAsync(async (inn, CancellationToken) =>
                {
                    var innExists = await supplierReadRepository.AnyByInnAsync(inn, CancellationToken);
                    return !innExists;
                }).WithMessage("Такой ИНН уже существует.");

            RuleFor(supplier => supplier.Phone)
                .NotNull().WithMessage("Номер телефона не должен быть null.")
                .NotEmpty().WithMessage("Номер телефона не должен быть пустым.")
                .Length(2, 20).WithMessage("Номер телефона не должен быть меньше 2 и больше 20 символов.")
                .MustAsync(async (phone, CancellationToken) =>
                {
                    var phoneExists = await supplierReadRepository.AnyByPhoneAsync(phone, CancellationToken);
                    return !phoneExists;
                }).WithMessage("Такой номер уже существует.");

            RuleFor(supplier => supplier.Description)
                .MaximumLength(100).WithMessage("Описание не должно быть больше 100 символов.");
        }
    }
}