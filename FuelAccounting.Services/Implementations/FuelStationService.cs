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
    public class FuelStationService : IFuelStationService, IServiceAnchor
    {
        private readonly IFuelStationReadRepository fuelStationReadRepository;
        private readonly IFuelStationWriteRepository fuelStationWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FuelStationService(IFuelStationReadRepository fuelStationReadRepository,
            IFuelStationWriteRepository fuelStationWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.fuelStationReadRepository = fuelStationReadRepository;
            this.fuelStationWriteRepository = fuelStationWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<FuelStationModel>> IFuelStationService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await fuelStationReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<FuelStationModel>>(result);
        }

        async Task<FuelStationModel> IFuelStationService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await fuelStationReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<FuelStation>(id);
            }

            return mapper.Map<FuelStationModel>(item);
        }

        async Task<FuelStationModel> IFuelStationService.AddAsync(FuelStationRequestModel fuelStation, CancellationToken cancellationToken)
        {
            var item = new FuelStation
            {
                Id = Guid.NewGuid(),
                Name = fuelStation.Name.Trim(),
                Address = fuelStation.Address.Trim(),
                Description = string.IsNullOrWhiteSpace(fuelStation.Description) ? null : fuelStation.Description.Trim(),
            };

            fuelStationWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FuelStationModel>(item);
        }

        async Task<FuelStationModel> IFuelStationService.EditAsync(FuelStationRequestModel source, CancellationToken cancellationToken)
        {
            var targetFuelStation = await fuelStationReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetFuelStation == null)
            {
                throw new FuelAccountingEntityNotFoundException<FuelStation>(source.Id);
            }

            targetFuelStation.Name = source.Name.Trim();
            targetFuelStation.Address = source.Address.Trim();
            targetFuelStation.Description = string.IsNullOrWhiteSpace(source.Description) ? null : source.Description.Trim();

            fuelStationWriteRepository.Update(targetFuelStation);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FuelStationModel>(targetFuelStation);
        }

        async Task IFuelStationService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetFuelStation = await fuelStationReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetFuelStation == null)
            {
                throw new FuelAccountingEntityNotFoundException<FuelStation>(id);
            }

            fuelStationWriteRepository.Delete(targetFuelStation);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
