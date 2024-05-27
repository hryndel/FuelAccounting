using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using FuelAccounting.Common;
using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.Exceptions;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;
using System.Drawing;

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
        private readonly IFuelWriteRepository fuelWriteRepository;
        private readonly IFuelStationReadRepository fuelStationReadRepository;
        private readonly ISupplierReadRepository supplierReadRepository;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IConverter converter;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FuelAccountingItemService(IFuelAccountingItemReadRepository fuelDeliveryItemReadRepository,
            IFuelAccountingItemWriteRepository fuelDeliveryItemWriteRepository,
            IDriverReadRepository driverReadRepository,
            ITruckReadRepository truckReadRepository,
            ITrailerReadRepository trailerReadRepository,
            IFuelReadRepository fuelReadRepository,
            IFuelWriteRepository fuelWriteRepository,
            IFuelStationReadRepository fuelStationReadRepository,
            ISupplierReadRepository supplierReadRepository,
            IDateTimeProvider dateTimeProvider,
            IConverter converter,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.fuelDeliveryItemReadRepository = fuelDeliveryItemReadRepository;
            this.fuelDeliveryItemWriteRepository = fuelDeliveryItemWriteRepository;
            this.driverReadRepository = driverReadRepository;
            this.truckReadRepository = truckReadRepository;
            this.trailerReadRepository = trailerReadRepository;
            this.fuelReadRepository = fuelReadRepository;
            this.fuelWriteRepository = fuelWriteRepository;
            this.fuelStationReadRepository = fuelStationReadRepository;
            this.supplierReadRepository = supplierReadRepository;
            this.dateTimeProvider = dateTimeProvider;
            this.converter = converter;
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
                
                var supplier = await supplierReadRepository.GetByIdAsync(fuel.SupplierId, cancellationToken);
                if (supplier == null) continue;
                
                var fuelDelivery = mapper.Map<FuelAccountingItemModel>(fuelDeliveryItem);
                fuelDelivery.Driver = mapper.Map<DriverModel>(driver);
                fuelDelivery.Truck = mapper.Map<TruckModel>(truck);
                fuelDelivery.Trailer = mapper.Map<TrailerModel>(trailer);
                fuelDelivery.Fuel = mapper.Map<FuelModel>(fuel);
                fuelDelivery.Fuel.Supplier = mapper.Map<SupplierModel>(supplier);
                fuelDelivery.FuelStation = mapper.Map<FuelStationModel>(fuelStation);
                listFuelDeliveryItemModel.Add(fuelDelivery);
            }

            return listFuelDeliveryItemModel;
        }

        async Task<FuelAccountingItemModel> IFuelAccountingItemService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
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
            var supplier = await supplierReadRepository.GetByIdAsync(fuel.SupplierId, cancellationToken);
            var fuelStation = await fuelStationReadRepository.GetByIdAsync(item.FuelStationId, cancellationToken);
            var fuelDelivery = mapper.Map<FuelAccountingItemModel>(item);

            fuelDelivery.Driver = mapper.Map<DriverModel>(driver);
            fuelDelivery.Truck = mapper.Map<TruckModel>(truck);
            fuelDelivery.Trailer = mapper.Map<TrailerModel>(trailer);
            fuelDelivery.Fuel = mapper.Map<FuelModel>(fuel);
            fuelDelivery.Fuel.Supplier = mapper.Map<SupplierModel>(supplier);
            fuelDelivery.FuelStation = mapper.Map<FuelStationModel>(fuelStation);
            return fuelDelivery;
        }

        async Task<FuelAccountingItemModel> IFuelAccountingItemService.AddAsync(FuelAccountingItemRequestModel fuelDeliveryItem, CancellationToken cancellationToken)
        {
            var trailer = await trailerReadRepository.GetByIdAsync(fuelDeliveryItem.TrailerId, cancellationToken);
            var fuel = await fuelReadRepository.GetByIdAsync(fuelDeliveryItem.FuelId, cancellationToken);
            if (fuelDeliveryItem.Count > trailer!.Capacity)
            {
                throw new FuelAccountingInvalidOperationException("Количество заказываемого топлива не может быть больше, чем в полуприцепе.");
            }

            if (fuelDeliveryItem.Count > fuel!.Count)
            {
                throw new FuelAccountingInvalidOperationException("Количество заказываемого топлива не может быть больше, чем на базе.");
            }

            if (fuelDeliveryItem.StartDate == fuelDeliveryItem.EndDate)
            {
                throw new FuelAccountingInvalidOperationException("Дата и время отправки не может совпадать с прибытием.");
            }

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

            fuelWriteRepository.UpdateFuelCount(fuel, item.Count);
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

            if (source.StartDate == source.EndDate)
            {
                throw new FuelAccountingInvalidOperationException("Дата и время отправки не может совпадать с прибытием.");
            }

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

            if (targetFuelDeliveryItem.Count > trailer.Capacity)
            {
                throw new FuelAccountingInvalidOperationException("Количество заказываемого топлива не может быть больше, чем в полуприцепе.");
            }

            if (fuel.Count + targetFuelDeliveryItem.Count - source.Count < 0)
            {
                throw new FuelAccountingInvalidOperationException("Количество заказываемого топлива не может быть больше, чем на базе.");
            }

            fuelWriteRepository.UpdateFuelCount(fuel, targetFuelDeliveryItem.Count - source.Count);

            targetFuelDeliveryItem.Count = source.Count;
            targetFuelDeliveryItem.StartDate = source.StartDate;
            targetFuelDeliveryItem.EndDate = source.EndDate;

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

            var fuel = await fuelReadRepository.GetByIdAsync(targetFuelDeliveryItem.FuelId, cancellationToken);

            if (fuel != null && dateTimeProvider.UtcNow < targetFuelDeliveryItem.EndDate)
            {
                fuelWriteRepository.UpdateFuelCount(fuel, -targetFuelDeliveryItem.Count);
            }

            fuelDeliveryItemWriteRepository.Delete(targetFuelDeliveryItem);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        async Task<byte[]> IFuelAccountingItemService.GetDocumentById(Guid id, string path, CancellationToken cancellationToken)
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
            var supplier = await supplierReadRepository.GetByIdAsync(fuel!.SupplierId, cancellationToken);
            var fuelDelivery = mapper.Map<FuelAccountingItemModel>(item);

            fuelDelivery.Driver = mapper.Map<DriverModel>(driver);
            fuelDelivery.Truck = mapper.Map<TruckModel>(truck);
            fuelDelivery.Trailer = mapper.Map<TrailerModel>(trailer);
            fuelDelivery.Fuel = mapper.Map<FuelModel>(fuel);
            fuelDelivery.FuelStation = mapper.Map<FuelStationModel>(fuelStation);
            
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                text = text.Replace("%id%", fuelDelivery.Id.ToString());
                text = text.Replace("%dateStart%", fuelDelivery.StartDate.LocalDateTime.ToString("g"));
                text = text.Replace("%dateEnd%", fuelDelivery.EndDate.LocalDateTime.ToString("g"));
                text = text.Replace("%driverFio%", $"{fuelDelivery.Driver.FirstName} {fuelDelivery.Driver.LastName} {fuelDelivery.Driver.Patronymic}");
                text = text.Replace("%driverDriversLicense%", fuelDelivery.Driver.DriversLicense);
                text = text.Replace("%truckName%", fuelDelivery.Truck.Name);
                text = text.Replace("%truckNumber%", fuelDelivery.Truck.Number);
                text = text.Replace("%truckVin%", fuelDelivery.Truck.Vin);
                text = text.Replace("%trailerName%",fuelDelivery.Trailer.Name); 
                text = text.Replace("%trailerNumber%", fuelDelivery.Trailer.Number);
                text = text.Replace("%trailerCapacity%", fuelDelivery.Trailer.Capacity.ToString());
                text = text.Replace("%fuelStation%", fuelDelivery.FuelStation.Name);
                text = text.Replace("%fuelStationAddress%", fuelDelivery.FuelStation.Address);
                text = text.Replace("%fuel%", fuelDelivery.Fuel.FuelType.ToString());
                text = text.Replace("%supplier%", supplier!.Name);
                text = text.Replace("%count%", fuelDelivery.Count.ToString());
                text = text.Replace("%price%", fuelDelivery.Fuel.Price.ToString());
                text = text.Replace("%fullPrice%", $"{fuelDelivery.Count * fuelDelivery.Fuel.Price} руб.");

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "Накладная"
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = text,
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                return converter.Convert(pdf);
            }
        }
    }
}
