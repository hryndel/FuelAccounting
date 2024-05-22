using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.Supplier;
using FuelAccounting.Context.Contracts.Enums;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(IEnumerable<SupplierResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await supplierService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<SupplierResponse>>(result));
        }

        /// <summary>
        /// Получить поставщика по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(SupplierResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await supplierService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<SupplierResponse>(item));
        }

        /// <summary>
        /// Создать нового поставщика
        /// </summary>
        [HttpPost]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
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
        /// Редактировать поставщика
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
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
        /// Удалить поставщика по id
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk]
        [ApiNotFound]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await supplierService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
