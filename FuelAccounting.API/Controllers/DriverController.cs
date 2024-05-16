using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.Driver;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с водителями
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Driver")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DriverController"/>
        /// </summary>
        public DriverController(IDriverService driverService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.driverService = driverService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех водителей
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<DriverResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await driverService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<DriverResponse>>(result));
        }

        /// <summary>
        /// Получает водителя по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(DriverResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await driverService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<DriverResponse>(item));
        }

        /// <summary>
        /// Создаёт нового водителя
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(DriverResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateDriverRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var driverRequestModel = mapper.Map<DriverRequestModel>(request);
            var result = await driverService.AddAsync(driverRequestModel, cancellationToken);
            return Ok(mapper.Map<DriverResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющегося водителя
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(DriverResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(DriverRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var driverRequestModel = mapper.Map<DriverRequestModel>(request);
            var result = await driverService.EditAsync(driverRequestModel, cancellationToken);
            return Ok(mapper.Map<DriverResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющегося водителя
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await driverService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
