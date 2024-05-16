using AutoMapper;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DriverService(IDriverReadRepository driverReadRepository, 
            IDriverWriteRepository driverWriteRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            this.driverReadRepository = driverReadRepository;
            this.driverWriteRepository = driverWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<DriverModel>> IDriverService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await driverReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<DriverModel>>(result);
        }

        async Task<DriverModel?> IDriverService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
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

            if (targetDriver.DeletedAt.HasValue)
            {
                throw new FuelAccountingInvalidOperationException($"Водитель с идентификатором {id} уже удален.");
            }

            driverWriteRepository.Delete(targetDriver);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
