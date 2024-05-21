using FluentValidation;
using FuelAccounting.API.ModelsRequest.Driver;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.Driver
{
    /// <summary>
    /// Валидатор класса <see cref="CreateDriverRequest"/>
    /// </summary>
    public class CreateDriverRequestValidator : AbstractValidator<CreateDriverRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="CreateDriverRequestValidator"/>
        /// </summary>
        public CreateDriverRequestValidator(IDriverReadRepository driverReadRepository)
        {
            RuleFor(driver => driver.FirstName)
                .NotNull().WithMessage("Имя не должно быть null.")
                .NotEmpty().WithMessage("Имя не должно быть пустым.")
                .Length(2, 50).WithMessage("Имя не должно быть меньше 2 и больше 50 символов.");

            RuleFor(driver => driver.LastName)
                .NotNull().WithMessage("Фамилия не должна быть null.")
                .NotEmpty().WithMessage("Фамилия не должна быть пустой.")
                .Length(2, 50).WithMessage("Фамилия не должна быть меньше 2 и больше 50 символов.");

            RuleFor(driver => driver.Patronymic)
                .NotEmpty().WithMessage("Отчество не должно быть пустым.")
                .MaximumLength(50).WithMessage("Отчество не должно быть больше 50 символов.");

            RuleFor(driver => driver.Phone)
                .NotNull().WithMessage("Телефон не должен быть null")
                .NotEmpty().WithMessage("Телефон не должен быть пустым")
                .Length(2, 20).WithMessage("Телефон не должен быть меньше 2 и больше 20 символов")
                .MustAsync(async (phone, CancellationToken) =>
                {
                    var phoneExists = await driverReadRepository.AnyByPhoneAsync(phone, CancellationToken);
                    return !phoneExists;
                }).WithMessage("Такой номер уже существует.");

            RuleFor(driver => driver.DriversLicense)
                .NotNull().WithMessage("Лицензия не должна быть null")
                .NotEmpty().WithMessage("Лицензия не должна быть пустой")
                .Length(2, 15).WithMessage("Лицензия не должна быть меньше 2 и больше 15 символов")
                .MustAsync(async (driverLicense, CancellationToken) =>
                {
                    var driversLicenseExists = await driverReadRepository.AnyByDriversLicenseAsync(driverLicense, CancellationToken);
                    return !driversLicenseExists;
                }).WithMessage("Такая лицензия уже существует.");
        }
    }
}
