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
    public class TruckService : ITruckService, IServiceAnchor
    {
        private readonly ITruckReadRepository truckReadRepository;
        private readonly ITruckWriteRepository truckWriteRepository;
        private readonly IFuelAccountingItemReadRepository fuelAccountingItemReadRepository;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TruckService(ITruckReadRepository truckReadRepository,
            ITruckWriteRepository truckWriteRepository,
            IFuelAccountingItemReadRepository fuelAccountingItemReadRepository,
            IDateTimeProvider dateProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.truckReadRepository = truckReadRepository;
            this.truckWriteRepository = truckWriteRepository;
            this.fuelAccountingItemReadRepository = fuelAccountingItemReadRepository;
            this.dateTimeProvider = dateProvider;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<TruckModel>> ITruckService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await truckReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<TruckModel>>(result);
        }

        async Task<TruckModel> ITruckService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await truckReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<Truck>(id);
            }

            return mapper.Map<TruckModel>(item);
        }

        async Task<IEnumerable<TruckModel>> ITruckService.GetFreeAllAsync(CancellationToken cancellationToken)
        {
            var result = await truckReadRepository.GetAllAsync(cancellationToken);
            var listTruckModel = new List<TruckModel>();
            foreach (var item in result)
            {
                var document = await fuelAccountingItemReadRepository.GetByTruckIdAsync(item.Id, cancellationToken);
                if (document != null || dateTimeProvider.UtcNow < document?.EndDate) continue;
                var truck = mapper.Map<TruckModel>(item);
                listTruckModel.Add(truck);
            }

            return listTruckModel;
        }

        async Task<TruckModel> ITruckService.AddAsync(TruckRequestModel truck, CancellationToken cancellationToken)
        {
            var item = new Truck
            {
                Id = Guid.NewGuid(),
                Name = truck.Name.Trim(),
                Number = truck.Number.Trim(),
                Vin = truck.Vin.Trim()
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

            targetTruck.Name = source.Name.Trim();
            targetTruck.Number = source.Number.Trim();
            targetTruck.Vin = source.Vin.Trim();

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

            truckWriteRepository.Delete(targetDriver);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
