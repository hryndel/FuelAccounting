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
    public class FuelAccountingItemService : IFuelAccountingItemService, IServiceAnchor
    {
        private readonly IFuelAccountingItemReadRepository fuelDeliveryItemReadRepository;
        private readonly IFuelAccountingItemWriteRepository fuelDeliveryItemWriteRepository;
        private readonly IDriverReadRepository driverReadRepository;
        private readonly ITruckReadRepository truckReadRepository;
        private readonly ITrailerReadRepository trailerReadRepository;
        private readonly IFuelReadRepository fuelReadRepository;
        private readonly IFuelStationReadRepository fuelStationReadRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FuelAccountingItemService(IFuelAccountingItemReadRepository fuelDeliveryItemReadRepository,
            IFuelAccountingItemWriteRepository fuelDeliveryItemWriteRepository,
            IDriverReadRepository driverReadRepository,
            ITruckReadRepository truckReadRepository,
            ITrailerReadRepository trailerReadRepository,
            IFuelReadRepository fuelReadRepository,
            IFuelStationReadRepository fuelStationReadRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.fuelDeliveryItemReadRepository = fuelDeliveryItemReadRepository;
            this.fuelDeliveryItemWriteRepository = fuelDeliveryItemWriteRepository;
            this.driverReadRepository = driverReadRepository;
            this.truckReadRepository = truckReadRepository;
            this.trailerReadRepository = trailerReadRepository;
            this.fuelReadRepository = fuelReadRepository;
            this.fuelStationReadRepository = fuelStationReadRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<FuelAccountingItemModel>> IFuelAccountingItemService.GetAllAsync(CancellationToken cancellationToken)
        {
            var fuelDeliveryItems = await fuelDeliveryItemReadRepository.GetAllAsync(cancellationToken);

            var driverId = fuelDeliveryItems.Select(x => x.DriverId).Distinct();
            var truckId = fuelDeliveryItems.Select(x => x.TruckId).Distinct();
            var trailerId = fuelDeliveryItems.Select(x => x.TrailerId).Distinct();
            var fuelId = fuelDeliveryItems.Select(x => x.FuelId).Distinct();
            var fuelStationId = fuelDeliveryItems.Select(x => x.FuelStationId).Distinct();

            var drivers = await driverReadRepository.GetByIdsAsync(driverId, cancellationToken);
            var trucks = await truckReadRepository.GetByIdsAsync(truckId, cancellationToken);
            var trailers = await trailerReadRepository.GetByIdsAsync(trailerId, cancellationToken);
            var fuels = await fuelReadRepository.GetByIdsAsync(fuelId, cancellationToken);
            var fuelStations = await fuelStationReadRepository.GetByIdsAsync(fuelStationId, cancellationToken);

            var listFuelDeliveryItemModel = new List<FuelAccountingItemModel>();
            foreach (var fuelDeliveryItem in fuelDeliveryItems)
            {
                if (!drivers.TryGetValue(fuelDeliveryItem.DriverId, out var driver)) continue;
                if (!trucks.TryGetValue(fuelDeliveryItem.TruckId, out var truck)) continue;
                if (!trailers.TryGetValue(fuelDeliveryItem.TrailerId, out var trailer)) continue;
                if (!fuels.TryGetValue(fuelDeliveryItem.FuelId, out var fuel)) continue;
                if (!fuelStations.TryGetValue(fuelDeliveryItem.FuelStationId, out var fuelStation)) continue;
                
                var fuelDelivery = mapper.Map<FuelAccountingItemModel>(fuelDeliveryItem);
                fuelDelivery.Driver = mapper.Map<DriverModel>(driver);
                fuelDelivery.Truck = mapper.Map<TruckModel>(truck);
                fuelDelivery.Trailer = mapper.Map<TrailerModel>(trailer);
                fuelDelivery.Fuel = mapper.Map<FuelModel>(fuel);
                fuelDelivery.FuelStation = mapper.Map<FuelStationModel>(fuelStation);
                listFuelDeliveryItemModel.Add(fuelDelivery);
            }

            return listFuelDeliveryItemModel;
        }

        async Task<FuelAccountingItemModel?> IFuelAccountingItemService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await fuelDeliveryItemReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<FuelAccountingItem>(id);
            }

            var driver = await driverReadRepository.GetByIdAsync(item.DriverId, cancellationToken);
            var truck = await truckReadRepository.GetByIdAsync(item.TruckId, cancellationToken);
            var trailer = await trailerReadRepository.GetByIdAsync(item.TrailerId, cancellationToken);
            var fuel = await fuelReadRepository.GetByIdAsync(item.FuelId, cancellationToken);
            var fuelStation = await fuelStationReadRepository.GetByIdAsync(item.FuelStationId, cancellationToken);
            var fuelDelivery = mapper.Map<FuelAccountingItemModel>(item);

            fuelDelivery.Driver = mapper.Map<DriverModel>(driver);
            fuelDelivery.Truck = mapper.Map<TruckModel>(truck);
            fuelDelivery.Trailer = mapper.Map<TrailerModel>(trailer);
            fuelDelivery.Fuel = mapper.Map<FuelModel>(fuel);
            fuelDelivery.FuelStation = mapper.Map<FuelStationModel>(fuelStation);
            return fuelDelivery;
        }

        async Task<FuelAccountingItemModel> IFuelAccountingItemService.AddAsync(FuelAccountingItemRequestModel fuelDeliveryItem, CancellationToken cancellationToken)
        {
            var item = new FuelAccountingItem
            {
                Id = Guid.NewGuid(),
                DriverId = fuelDeliveryItem.DriverId,
                TruckId = fuelDeliveryItem.TruckId,
                TrailerId = fuelDeliveryItem.TrailerId,
                FuelId = fuelDeliveryItem.FuelId,
                Count = fuelDeliveryItem.Count,
                FuelStationId = fuelDeliveryItem.FuelStationId,
                StartDate = fuelDeliveryItem.StartDate,
                EndDate = fuelDeliveryItem.EndDate
            };

            fuelDeliveryItemWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FuelAccountingItemModel>(item);
        }

        async Task<FuelAccountingItemModel> IFuelAccountingItemService.EditAsync(FuelAccountingItemRequestModel source, CancellationToken cancellationToken)
        {
            var targetFuelDeliveryItem = await fuelDeliveryItemReadRepository.GetByIdAsync(source.Id, cancellationToken);

            if (targetFuelDeliveryItem == null)
            {
                throw new FuelAccountingEntityNotFoundException<FuelAccountingItem>(source.Id);
            }

            targetFuelDeliveryItem.Count = source.Count;
            targetFuelDeliveryItem.StartDate = source.StartDate;
            targetFuelDeliveryItem.EndDate = source.EndDate;

            var driver = await driverReadRepository.GetByIdAsync(source.DriverId, cancellationToken);
            targetFuelDeliveryItem.DriverId = driver!.Id;
            targetFuelDeliveryItem.Driver = driver;
            
            var truck = await truckReadRepository.GetByIdAsync(source.TruckId, cancellationToken);
            targetFuelDeliveryItem.TruckId = truck!.Id;
            targetFuelDeliveryItem.Truck = truck;

            var trailer = await trailerReadRepository.GetByIdAsync(source.TrailerId, cancellationToken);
            targetFuelDeliveryItem.TrailerId = trailer!.Id;
            targetFuelDeliveryItem.Trailer = trailer;

            var fuel = await fuelReadRepository.GetByIdAsync(source.FuelId, cancellationToken);
            targetFuelDeliveryItem.FuelId = fuel!.Id;
            targetFuelDeliveryItem.Fuel = fuel;

            var fuelStation = await fuelStationReadRepository.GetByIdAsync(source.FuelStationId, cancellationToken);
            targetFuelDeliveryItem.FuelStationId = fuelStation!.Id;
            targetFuelDeliveryItem.FuelStation = fuelStation;

            fuelDeliveryItemWriteRepository.Update(targetFuelDeliveryItem);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FuelAccountingItemModel>(targetFuelDeliveryItem);
        }

        async Task IFuelAccountingItemService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetFuelDeliveryItem = await fuelDeliveryItemReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetFuelDeliveryItem == null)
            {
                throw new FuelAccountingEntityNotFoundException<FuelAccountingItem>(id);
            }

            if (targetFuelDeliveryItem.DeletedAt.HasValue)
            {
                throw new FuelAccountingInvalidOperationException($"Документ с идентификатором {id} уже удален");
            }

            fuelDeliveryItemWriteRepository.Delete(targetFuelDeliveryItem);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
