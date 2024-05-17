using FluentValidation;
using FuelAccounting.API.Validators.Driver;
using FuelAccounting.API.Validators.Fuel;
using FuelAccounting.API.Validators.FuelAccountingItem;
using FuelAccounting.API.Validators.FuelStation;
using FuelAccounting.API.Validators.Supplier;
using FuelAccounting.API.Validators.Trailer;
using FuelAccounting.API.Validators.Truck;
using FuelAccounting.API.Validators.User;
using FuelAccounting.Repositories.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.Exceptions;
using FuelAccounting.Shared;

namespace FuelAccounting.API.Infrastructures.Validator
{
    internal sealed class ApiValidatorService : IApiValidatorService
    {
        private readonly Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        public ApiValidatorService(IDriverReadRepository driverReadRepository,
            ITruckReadRepository truckReadRepository,
            ITrailerReadRepository trailerReadRepository,
            IFuelReadRepository fuelReadRepository,
            IFuelStationReadRepository fuelStationReadRepository, 
            ISupplierReadRepository supplierReadRepository,
            IUserReadRepository userReadRepository)
        {
            Register<CreateDriverRequestValidator>(driverReadRepository);
            Register<DriverRequestValidator>(driverReadRepository);

            Register<CreateFuelRequestValidator>(supplierReadRepository);
            Register<FuelRequestValidator>(supplierReadRepository);

            Register<CreateFuelAccountingItemRequestValidator>(driverReadRepository, truckReadRepository, trailerReadRepository, fuelReadRepository, fuelStationReadRepository);
            Register<FuelAccountingItemRequestValidator>(driverReadRepository, truckReadRepository, trailerReadRepository, fuelReadRepository, fuelStationReadRepository);

            Register<CreateFuelStationRequestValidator>(fuelStationReadRepository);
            Register<FuelStationRequestValidator>(fuelStationReadRepository);

            Register<CreateSupplierRequestValidator>(supplierReadRepository);
            Register<SupplierRequestValidator>(supplierReadRepository);

            Register<CreateTrailerRequestValidator>(trailerReadRepository);
            Register<TrailerRequestValidator>(trailerReadRepository);

            Register<CreateTruckRequestValidator>(truckReadRepository);
            Register<TruckRequestValidator>(truckReadRepository);

            Register<CreateUserRequestValidator>(userReadRepository);
            Register<UserRequestValidator>(userReadRepository);
        }

        ///<summary>
        /// Регистрирует валидатор в словаре
        /// </summary>
        public void Register<TValidator>(params object[] constructorParams)
            where TValidator : IValidator
        {
            var validatorType = typeof(TValidator);
            var innerType = validatorType.BaseType?.GetGenericArguments()[0];
            if (innerType == null)
            {
                throw new ArgumentNullException($"Указанный валидатор {validatorType} должен быть generic от типа IValidator");
            }

            if (constructorParams?.Any() == true)
            {
                var validatorObject = Activator.CreateInstance(validatorType, constructorParams);
                if (validatorObject is IValidator validator)
                {
                    validators.TryAdd(innerType, validator);
                }
            }
            else
            {
                validators.TryAdd(innerType, Activator.CreateInstance<TValidator>());
            }
        }

        public async Task ValidateAsync<TModel>(TModel model, CancellationToken cancellationToken)
            where TModel : class
        {
            var modelType = model.GetType();
            if (!validators.TryGetValue(modelType, out var validator))
            {
                throw new InvalidOperationException($"Не найден валидатор для модели {modelType}");
            }

            var context = new ValidationContext<TModel>(model);
            var result = await validator.ValidateAsync(context, cancellationToken);

            if (!result.IsValid)
            {
                throw new FuelAccountingValidationException(result.Errors.Select(x =>
                InvalidateItemModel.New(x.PropertyName, x.ErrorMessage)));
            }
        }
    }
}
