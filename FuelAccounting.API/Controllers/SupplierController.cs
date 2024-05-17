using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.Supplier;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с поставщиками
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Supplier")]

    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="SupplierController"/>
        /// </summary>
        public SupplierController(ISupplierService supplierService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех поставщиков
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<SupplierResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await supplierService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<SupplierResponse>>(result));
        }

        /// <summary>
        /// Получает поставщика по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(SupplierResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await supplierService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<SupplierResponse>(item));
        }

        /// <summary>
        /// Создаёт нового поставщика
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(SupplierResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var supplierRequestModel = mapper.Map<SupplierRequestModel>(request);
            var result = await supplierService.AddAsync(supplierRequestModel, cancellationToken);
            return Ok(mapper.Map<SupplierResponse>(result));
        }

        /// <summary>
        /// Редактирует поставщика
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(SupplierResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(SupplierRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var supplierRequestModel = mapper.Map<SupplierRequestModel>(request);
            var result = await supplierService.EditAsync(supplierRequestModel, cancellationToken);
            return Ok(mapper.Map<SupplierResponse>(result));
        }

        /// <summary>
        /// Удаляет поставщика по id
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await supplierService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
