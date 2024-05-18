using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.Fuel;
using FuelAccounting.Context.Contracts.Enums;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с топливом
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Fuel")]
    public class FuelController : ControllerBase
    {
        private readonly IFuelService fuelService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelController"/>
        /// </summary>
        public FuelController(IFuelService fuelService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.fuelService = fuelService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех видов топлива
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(IEnumerable<FuelResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await fuelService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<FuelResponse>>(result));
        }

        /// <summary>
        /// Получить топливо по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await fuelService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<FuelResponse>(item));
        }

        /// <summary>
        /// Создать новое топливо
        /// </summary>
        [HttpPost]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateFuelRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var fuelRequestModel = mapper.Map<FuelRequestModel>(request);
            var result = await fuelService.AddAsync(fuelRequestModel, cancellationToken);
            return Ok(mapper.Map<FuelResponse>(result));
        }

        /// <summary>
        /// Редактировать топливо
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(FuelRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var fuelRequestModel = mapper.Map<FuelRequestModel>(request);
            var result = await fuelService.EditAsync(fuelRequestModel, cancellationToken);
            return Ok(mapper.Map<FuelResponse>(result));
        }

        /// <summary>
        /// Удалить топливо по id
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await fuelService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
