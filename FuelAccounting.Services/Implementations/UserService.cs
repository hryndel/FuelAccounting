﻿using AutoMapper;
using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Enums;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.Exceptions;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Implementations
{
    public class UserService : IUserService, IServiceAnchor
    {
        private readonly IUserReadRepository userReadRepository;
        private readonly IUserWriteRepository userWriteRepository;
        private readonly IIdentityProvider identityProvider;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUserReadRepository userReadRepository,
            IUserWriteRepository userWriteRepository,
            IIdentityProvider identityProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.userReadRepository = userReadRepository;
            this.userWriteRepository = userWriteRepository;
            this.identityProvider = identityProvider;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<UserModel>> IUserService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await userReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<UserModel>>(result);
        }

        async Task<UserModel> IUserService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await userReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<User>(id);
            }

            return mapper.Map<UserModel>(item);
        }

        async Task<UserModel> IUserService.AddAsync(UserRequestModel user, CancellationToken cancellationToken)
        {
            var item = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName.Trim(),
                LastName = user.LastName.Trim(),
                Patronymic = string.IsNullOrWhiteSpace(user.Patronymic) ? null : user.Patronymic.Trim(),
                Mail = user.Mail.Trim(),
                Login = user.Login.Trim(),
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password.Trim()),
                UserType = (UserTypes)user.UserType
            };

            userWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<UserModel>(item);
        }

        async Task<UserModel> IUserService.EditAsync(UserRequestModel source, CancellationToken cancellationToken)
        {
            var targetUser = await userReadRepository.GetByIdAsync(source.Id, cancellationToken);
            var countAdmins = await userReadRepository.GetByAdminRoleAsync(cancellationToken);
            if (targetUser == null)
            {
                throw new FuelAccountingEntityNotFoundException<User>(source.Id);
            }

            if (countAdmins.Count == 1 && targetUser.UserType == UserTypes.Administrator && (UserTypes)source.UserType != targetUser.UserType)
            {
                throw new FuelAccountingInvalidOperationException($"Нельзя изменить роль последнему администратору.");
            }

            targetUser.FirstName = source.FirstName.Trim();
            targetUser.LastName = source.LastName.Trim();
            targetUser.Patronymic = string.IsNullOrWhiteSpace(source.Patronymic) ? null : source.Patronymic.Trim();
            targetUser.Mail = source.Mail.Trim();
            targetUser.Login = source.Login.Trim();
            targetUser.Password = BCrypt.Net.BCrypt.HashPassword(source.Password.Trim());
            targetUser.UserType = (UserTypes)source.UserType;

            userWriteRepository.Update(targetUser);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<UserModel>(targetUser);
        }

        async Task IUserService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetUser = await userReadRepository.GetByIdAsync(id, cancellationToken);
            var countAdmins = await userReadRepository.GetByAdminRoleAsync(cancellationToken);
            if (targetUser == null)
            {
                throw new FuelAccountingEntityNotFoundException<User>(id);
            }

            if (targetUser.Login == identityProvider.Name)
            {
                throw new FuelAccountingInvalidOperationException($"Нельзя удалить свою учетную запись.");
            }

            if (countAdmins.Count == 1 && targetUser.UserType == UserTypes.Administrator)
            {
                throw new FuelAccountingInvalidOperationException($"Нельзя удалить последнего администратора.");
            }

            userWriteRepository.Delete(targetUser);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

