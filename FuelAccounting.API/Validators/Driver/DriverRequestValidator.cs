using FluentValidation;
using FuelAccounting.API.ModelsRequest.Driver;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.Driver
{
    /// <summary>
    /// Валидатор класса <see cref="DriverRequest"/>
    /// </summary>
    public class DriverRequestValidator : AbstractValidator<DriverRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="DriverRequestValidator"/>
        /// </summary>
        public DriverRequestValidator(IDriverReadRepository driverReadRepository)
        {
            RuleFor(driver => driver.Id)
                .NotNull().WithMessage("Id не должно быть null")
                .NotEmpty().WithMessage("Id не должно быть пустым");

            RuleFor(driver => driver.FirstName)
                .NotNull().WithMessage("Имя не должно быть null.")
                .NotEmpty().WithMessage("Имя не должно быть пустым.")
                .Length(2, 50).WithMessage("Имя не должно быть меньше 2 и больше 50 символов.");

            RuleFor(driver => driver.LastName)
                .NotNull().WithMessage("Фамилия не должна быть null.")
                .NotEmpty().WithMessage("Фамилия не должна быть пустой.")
                .Length(2, 50).WithMessage("Фамилия не должна быть меньше 2 и больше 50 символов.");

            RuleFor(driver => driver.Patronymic)
                .MaximumLength(50).WithMessage("Отчество не должно быть больше 50 символов.");

            RuleFor(driver => driver.Phone)
                .NotNull().WithMessage("Телефон не должен быть null")
                .NotEmpty().WithMessage("Телефон не должен быть пустым")
                .Length(2, 20).WithMessage("Телефон не должен быть меньше 2 и больше 20 символов")
                .Matches(@"^[1-9][(]\d{3}[)][-]\d{3}[-]\d{2}[-]\d{2}").WithMessage("Номер должен быть действительным.")
                .Must((driver, _) =>
                {
                    var phoneExists = driverReadRepository.AnyByPhoneAndId(driver.Phone, driver.Id);
                    return !phoneExists;
                }).WithMessage("Такой номер уже существует.");

            RuleFor(driver => driver.DriversLicense)
                .NotNull().WithMessage("Лицензия не должна быть null")
                .NotEmpty().WithMessage("Лицензия не должна быть пустой")
                .Length(2, 15).WithMessage("Лицензия не должна быть меньше 2 и больше 15 символов")
                .Matches(@"^\d{2}[-]\d{2}[-]\d{6}").WithMessage("Лицензия должна быть действительной.")
                .Must((driver, _) =>
                {
                    var driversLicenseExists = driverReadRepository.AnyByDriversLicenseAndId(driver.DriversLicense, driver.Id);
                    return !driversLicenseExists;
                }).WithMessage("Такая лицензия уже существует.");
        }
    }
}
