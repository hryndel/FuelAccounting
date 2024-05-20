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
    public class TrailerService : ITrailerService, IServiceAnchor
    {
        private readonly ITrailerReadRepository trailerReadRepository;
        private readonly ITrailerWriteRepository trailerWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TrailerService(ITrailerReadRepository trailerReadRepository,
            ITrailerWriteRepository trailerWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.trailerReadRepository = trailerReadRepository;
            this.mapper = mapper;
            this.trailerWriteRepository = trailerWriteRepository;
            this.unitOfWork = unitOfWork;
        }

        async Task<IEnumerable<TrailerModel>> ITrailerService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await trailerReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<TrailerModel>>(result);
        }

        async Task<TrailerModel> ITrailerService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await trailerReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new FuelAccountingEntityNotFoundException<Trailer>(id);
            }

            return mapper.Map<TrailerModel>(item);
        }

        async Task<TrailerModel> ITrailerService.AddAsync(TrailerRequestModel trailer, CancellationToken cancellationToken)
        {
            var item = new Trailer
            {
                Id = Guid.NewGuid(),
                Name = trailer.Name,
                Number = trailer.Number,
                Capacity = trailer.Capacity
            };

            trailerWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<TrailerModel>(item);
        }

        async Task<TrailerModel> ITrailerService.EditAsync(TrailerRequestModel source, CancellationToken cancellationToken)
        {
            var targetTrailer = await trailerReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetTrailer == null)
            {
                throw new FuelAccountingEntityNotFoundException<Trailer>(source.Id);
            }

            targetTrailer.Name = source.Name;
            targetTrailer.Number = source.Number;
            targetTrailer.Capacity = source.Capacity;

            trailerWriteRepository.Update(targetTrailer);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<TrailerModel>(targetTrailer);
        }

        async Task ITrailerService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetTrailer = await trailerReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetTrailer == null)
            {
                throw new FuelAccountingEntityNotFoundException<Trailer>(id);
            }

            trailerWriteRepository.Delete(targetTrailer);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
