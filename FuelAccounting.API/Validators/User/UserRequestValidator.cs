﻿using FluentValidation;
using FuelAccounting.API.ModelsRequest.User;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.API.Validators.User
{
    /// <summary>
    /// Валидатор класса <see cref="UserRequest"/>
    /// </summary>
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="UserRequestValidator"/>
        /// </summary>
        public UserRequestValidator(IUserReadRepository userReadRepository)
        {
            RuleFor(user => user.Id)
                .NotNull().WithMessage("Id не должно быть null")
                .NotEmpty().WithMessage("Id не должно быть пустым");

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
                .EmailAddress().WithMessage("Почта не действительна.")
                .Must((user, _) =>
                {
                    var mailExists = userReadRepository.AnyByMailAndId(user.Mail, user.Id);
                    return !mailExists;
                }).WithMessage("Такая почта уже существует.");

            RuleFor(user => user.Login)
                .NotNull().WithMessage("Логин не должен быть null.")
                .NotEmpty().WithMessage("Логин не должен быть пустой.")
                .Length(2, 20).WithMessage("Логин не должен быть меньше 2 и больше 20 символов.")
                .Must((user, _) =>
                {
                    var loginExists = userReadRepository.AnyByLoginAndId(user.Login, user.Id);
                    return !loginExists;
                }).WithMessage("Такой логин уже существует.");

            RuleFor(user => user.Password)
                .NotNull().WithMessage("Пароль не должен быть null.")
                .NotEmpty().WithMessage("Пароль не должен быть пустым.")
                .Matches(@"[0-9]+").WithMessage("Пароль должен содержать цифру.")
                .Matches(@"[A-Z]+").WithMessage("Пароль должен содержать прописную букву.")
                .Matches(@"[a-z]+").WithMessage("Пароль должен содержать строчную букву.")
                .Matches(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]+").WithMessage("Пароль должен содержать специальный символ.")
                .Length(2, 20).WithMessage("Пароль не должен быть меньше 2 и больше 20 символов.");

            RuleFor(user => user.UserType)
                .NotNull().WithMessage("Тип не должен быть null.")
                .IsInEnum().WithMessage("Тип не существует.");
        }
    }
}
