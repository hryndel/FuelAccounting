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
    public class TruckService : ITruckService, IServiceAnchor
    {
        private readonly ITruckReadRepository truckReadRepository;
        private readonly ITruckWriteRepository truckWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TruckService(ITruckReadRepository truckReadRepository,
            ITruckWriteRepository truckWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.truckReadRepository = truckReadRepository;
            this.mapper = mapper;
            this.truckWriteRepository = truckWriteRepository;
            this.unitOfWork = unitOfWork;
        }

        async Task<IEnumerable<TruckModel>> ITruckService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await truckReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<TruckModel>>(result);
        }

        async Task<TruckModel?> ITruckService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await truckReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<Truck>(id);
            }

            return mapper.Map<TruckModel?>(item);
        }

        async Task<TruckModel> ITruckService.AddAsync(TruckRequestModel truck, CancellationToken cancellationToken)
        {
            var item = new Truck
            {
                Id = Guid.NewGuid(),
                Name = truck.Name,
                Number = truck.Number,
                Vin = truck.Vin
            };

            truckWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<TruckModel>(item);
        }

        async Task<TruckModel> ITruckService.EditAsync(TruckRequestModel source, CancellationToken cancellationToken)
        {
            var targetTruck = await truckReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetTruck == null)
            {
                throw new FuelAccountingEntityNotFoundException<Truck>(source.Id);
            }

            targetTruck.Name = source.Name;
            targetTruck.Number = source.Number;
            targetTruck.Vin = source.Vin;

            truckWriteRepository.Update(targetTruck);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<TruckModel>(targetTruck);
        }

        async Task ITruckService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetDriver = await truckReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetDriver == null)
            {
                throw new FuelAccountingEntityNotFoundException<Truck>(id);
            }

            if (targetDriver.DeletedAt.HasValue)
            {
                throw new FuelAccountingInvalidOperationException($"Грузовик с идентификатором {id} уже удален");
            }

            truckWriteRepository.Delete(targetDriver);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
