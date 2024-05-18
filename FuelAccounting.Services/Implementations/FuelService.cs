using AutoMapper;
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
    public class FuelService : IFuelService, IServiceAnchor
    {
        private readonly IFuelReadRepository fuelReadRepository;
        private readonly IFuelWriteRepository fuelWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISupplierReadRepository supplierReadRepository;
        private readonly IMapper mapper;

        public FuelService(IFuelReadRepository fuelReadRepository,
            IFuelWriteRepository fuelWriteRepository,
            IUnitOfWork unitOfWork,
            ISupplierReadRepository supplierReadRepository,
            IMapper mapper)
        {
            this.fuelReadRepository = fuelReadRepository;
            this.fuelWriteRepository = fuelWriteRepository;
            this.unitOfWork = unitOfWork;
            this.supplierReadRepository = supplierReadRepository;
            this.mapper = mapper;
        }

        async Task<IEnumerable<FuelModel>> IFuelService.GetAllAsync(CancellationToken cancellationToken)
        {
            var fuels = await fuelReadRepository.GetAllAsync(cancellationToken);
            var suppliers = await supplierReadRepository.GetByIdsAsync(fuels.Select(x => x.SupplierId).Distinct(), cancellationToken);
            var result = new List<FuelModel>();
            foreach (var fuel in fuels)
            {
                if (!suppliers.TryGetValue(fuel.SupplierId, out var supplier)) continue;
                var fl = mapper.Map<FuelModel>(fuel);
                fl.Supplier = mapper.Map<SupplierModel>(supplier);
                result.Add(fl);
            }
            return result;
        }

        async Task<FuelModel> IFuelService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await fuelReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<Fuel>(id);
            }
            var supplier = await supplierReadRepository.GetByIdAsync(item.SupplierId, cancellationToken);
            var fuel = mapper.Map<FuelModel>(item);
            fuel.Supplier = mapper.Map<SupplierModel>(supplier);
            return fuel;
        }


        async Task<FuelModel> IFuelService.AddAsync(FuelRequestModel fuel, CancellationToken cancellationToken)
        {
            var item = new Fuel
            {
                Id = Guid.NewGuid(),
                FuelType = (FuelTypes)fuel.FuelType,
                Price = fuel.Price,
                SupplierId = fuel.SupplierId,
                Count = fuel.Count
            };

            fuelWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FuelModel>(item);
        }

        async Task<FuelModel> IFuelService.EditAsync(FuelRequestModel source, CancellationToken cancellationToken)
        {
            var targetFuel = await fuelReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetFuel == null)
            {
                throw new FuelAccountingEntityNotFoundException<Fuel>(source.Id);
            }

            targetFuel.FuelType = (FuelTypes)source.FuelType;
            targetFuel.Price = source.Price;
            targetFuel.Count = source.Count;

            var supplier = await supplierReadRepository.GetByIdAsync(source.SupplierId, cancellationToken);
            targetFuel.SupplierId = supplier!.Id;
            targetFuel.Supplier = supplier;

            fuelWriteRepository.Update(targetFuel);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FuelModel>(targetFuel);
        }

        async Task IFuelService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetFuel = await fuelReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetFuel == null)
            {
                throw new FuelAccountingEntityNotFoundException<Fuel>(id);
            }

            fuelWriteRepository.Delete(targetFuel);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
