using AutoMapper;
using FuelAccounting.Common;
using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.Exceptions;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Implementations
{
    public class DriverService : IDriverService, IServiceAnchor
    {
        private readonly IDriverReadRepository driverReadRepository;
        private readonly IDriverWriteRepository driverWriteRepository;
        private readonly IFuelAccountingItemReadRepository fuelAccountingItemReadRepository;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DriverService(IDriverReadRepository driverReadRepository, 
            IDriverWriteRepository driverWriteRepository,
            IFuelAccountingItemReadRepository fuelAccountingItemReadRepository,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            this.driverReadRepository = driverReadRepository;
            this.driverWriteRepository = driverWriteRepository;
            this.fuelAccountingItemReadRepository = fuelAccountingItemReadRepository;
            this.dateTimeProvider = dateTimeProvider;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<DriverModel>> IDriverService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await driverReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<DriverModel>>(result);
        }

        async Task<IEnumerable<DriverModel>> IDriverService.GetFreeAllAsync(CancellationToken cancellationToken)
        {
            var result = await driverReadRepository.GetAllAsync(cancellationToken);
            var listDriverModel = new List<DriverModel>();
            foreach (var item in result)
            {
                var document = await fuelAccountingItemReadRepository.GetByDriverIdAsync(item.Id, cancellationToken);
                if (document != null || dateTimeProvider.UtcNow < document?.EndDate) continue;
                var driver = mapper.Map<DriverModel>(item);
                listDriverModel.Add(driver);
            }
            
            return listDriverModel;
        }

        async Task<DriverModel> IDriverService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await driverReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<Driver>(id);
            }

            return mapper.Map<DriverModel>(item);
        }

        async Task<DriverModel> IDriverService.AddAsync(DriverRequestModel driver, CancellationToken cancellationToken)
        {
            var item = new Driver
            {
                Id = Guid.NewGuid(),
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Patronymic = driver.Patronymic,
                Phone = driver.Phone,
                DriversLicense = driver.DriversLicense
            };

            driverWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<DriverModel>(item);
        }

        async Task<DriverModel> IDriverService.EditAsync(DriverRequestModel source, CancellationToken cancellationToken)
        {
            var targetDriver = await driverReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetDriver == null)
            {
                throw new FuelAccountingEntityNotFoundException<Driver>(source.Id);
            }

            targetDriver.FirstName = source.FirstName;
            targetDriver.LastName = source.LastName;
            targetDriver.Patronymic = source.Patronymic;
            targetDriver.Phone = source.Phone;
            targetDriver.DriversLicense = source.DriversLicense;

            driverWriteRepository.Update(targetDriver);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<DriverModel>(targetDriver);
        }

        async Task IDriverService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetDriver = await driverReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetDriver == null)
            {
                throw new FuelAccountingEntityNotFoundException<Driver>(id);
            }

            driverWriteRepository.Delete(targetDriver);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
