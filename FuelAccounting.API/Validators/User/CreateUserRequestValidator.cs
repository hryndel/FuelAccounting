using FluentValidation;
using FuelAccounting.API.ModelsRequest.User;

namespace FuelAccounting.API.Validators.User
{
    /// <summary>
    /// Валидатор класса <see cref="CreateUserRequest"/>
    /// </summary>
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="CreateUserRequestValidator"/>
        /// </summary>
        public CreateUserRequestValidator()
        {
            RuleFor(user => user.FirstName)
                .NotNull().WithMessage("Имя не должно быть null.")
                .NotEmpty().WithMessage("Имя не должно быть пустым.")
                .Length(2, 50).WithMessage("Имя не должно быть меньше 2 и больше 50 символов.");

            RuleFor(user => user.LastName)
                .NotNull().WithMessage("Фамилия не должна быть null.")
                .NotEmpty().WithMessage("Фамилия не должна быть пустой.")
                .Length(2, 50).WithMessage("Фамилия не должна быть меньше 2 и больше 50 символов.");

            RuleFor(user => user.Patronymic)
                .MaximumLength(50).WithMessage("Отчество не должно быть больше 50 символов.");

            RuleFor(user => user.Mail)
                .NotNull().WithMessage("Почта не должна быть null.")
                .NotEmpty().WithMessage("Почта не должна быть пустой.")
                .Length(2, 320).WithMessage("Почта не должна быть меньше 2 и больше 50 символов.")
                .EmailAddress().WithMessage("Почта не действительна.");

            RuleFor(user => user.Login)
                .NotNull().WithMessage("Логин не должен быть null.")
                .NotEmpty().WithMessage("Логин не должен быть пустой.")
                .Length(2, 20).WithMessage("Логин не должен быть меньше 2 и больше 20 символов.");

            RuleFor(user => user.Password)
                .NotNull().WithMessage("Пароль не должен быть null.")
                .NotEmpty().WithMessage("Пароль не должен быть пустым.")
                .Length(2, 20).WithMessage("Пароль не должен быть меньше 2 и больше 20 символов.");
        
            RuleFor(user => user.UserType)
                .NotNull().WithMessage("Тип не должен быть null.")
                .NotEmpty().WithMessage("Тип не должен быть пустым.");
        }
    }
}
