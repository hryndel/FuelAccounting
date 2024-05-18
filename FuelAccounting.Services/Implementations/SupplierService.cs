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
    public class SupplierService : ISupplierService, IServiceAnchor
    {
        private readonly ISupplierReadRepository supplierReadRepository;
        private readonly ISupplierWriteRepository supplierWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SupplierService(ISupplierReadRepository supplierReadRepository,
            ISupplierWriteRepository supplierWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.supplierReadRepository = supplierReadRepository;
            this.supplierWriteRepository = supplierWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<SupplierModel>> ISupplierService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await supplierReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<SupplierModel>>(result);
        }

        async Task<SupplierModel> ISupplierService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await supplierReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<Supplier>(id);
            }

            return mapper.Map<SupplierModel>(item);
        }

        async Task<SupplierModel> ISupplierService.AddAsync(SupplierRequestModel supplier, CancellationToken cancellationToken)
        {
            var item = new Supplier
            {
                Id = Guid.NewGuid(),
                Name = supplier.Name,
                Inn = supplier.Inn,
                Phone = supplier.Phone,
                Description = supplier.Description
            };

            supplierWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<SupplierModel>(item);
        }

        async Task<SupplierModel> ISupplierService.EditAsync(SupplierRequestModel source, CancellationToken cancellationToken)
        {
            var targetSupplier = await supplierReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetSupplier == null)
            {
                throw new FuelAccountingEntityNotFoundException<Supplier>(source.Id);
            }

            targetSupplier.Name = source.Name;
            targetSupplier.Inn = source.Inn;
            targetSupplier.Phone = source.Phone;
            targetSupplier.Description = source.Description;

            supplierWriteRepository.Update(targetSupplier);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<SupplierModel>(targetSupplier);
        }

        async Task ISupplierService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetSupplier = await supplierReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetSupplier == null)
            {
                throw new FuelAccountingEntityNotFoundException<Supplier>(id);
            }

            supplierWriteRepository.Delete(targetSupplier);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
