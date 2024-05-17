using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.Truck;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с грузовиками
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Truck")]

    public class TruckController : ControllerBase
    {
        private readonly ITruckService truckService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TruckController"/>
        /// </summary>
        public TruckController(ITruckService truckService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.truckService = truckService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех грузовиков
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<TruckResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await truckService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<TruckResponse>>(result));
        }

        /// <summary>
        /// Получает грузовик по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(TruckResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await truckService.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return NotFound($"Не удалось найти грузовик с идентификатором {id}");
            }
            return Ok(mapper.Map<TruckResponse>(item));
        }

        /// <summary>
        /// Создаёт новый грузовик
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(TruckResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateTruckRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var truckRequestModel = mapper.Map<TruckRequestModel>(request);
            var result = await truckService.AddAsync(truckRequestModel, cancellationToken);
            return Ok(mapper.Map<TruckResponse>(result));
        }

        /// <summary>
        /// Редактирует грузовик
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(TruckResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(TruckRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var truckRequestModel = mapper.Map<TruckRequestModel>(request);
            var result = await truckService.EditAsync(truckRequestModel, cancellationToken);
            return Ok(mapper.Map<TruckResponse>(result));
        }

        /// <summary>
        /// Удаляет грузовик по id
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await truckService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
