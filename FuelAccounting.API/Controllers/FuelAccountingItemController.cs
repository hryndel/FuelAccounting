using AutoMapper;
using DinkToPdf.Contracts;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.FuelAccountingItem;
using FuelAccounting.Context.Contracts.Enums;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с накладными
    /// </summary>
    /// 
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "FuelAccountingItem")]
    public class FuelAccountingItemController : ControllerBase
    {
        private readonly IFuelAccountingItemService fuelAccountingItemService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelAccountingItemController"/>
        /// </summary>
        public FuelAccountingItemController(IFuelAccountingItemService fuelAccountingItemService, 
            IMapper mapper, 
            IApiValidatorService validatorService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.fuelAccountingItemService = fuelAccountingItemService;
            this.mapper = mapper;
            this.validatorService = validatorService;
            this.webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Получить список всех накладных
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(IEnumerable<FuelAccountingItemResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await fuelAccountingItemService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<FuelAccountingItemResponse>>(result));
        }

        /// <summary>
        /// Получить накладную по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelAccountingItemResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await fuelAccountingItemService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<FuelAccountingItemResponse>(item));
        }

        /// <summary>
        /// Создать новую накладную
        /// </summary>
        [HttpPost]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelAccountingItemResponse))]
        [ApiConflict]
        [ApiNotAcceptable]
        public async Task<IActionResult> Create(CreateFuelAccountingItemRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var fuelAccountingItemRequestModel = mapper.Map<FuelAccountingItemRequestModel>(request);
            var result = await fuelAccountingItemService.AddAsync(fuelAccountingItemRequestModel, cancellationToken);
            return Ok(mapper.Map<FuelAccountingItemResponse>(result));
        }

        /// <summary>
        /// Редактировать накладную
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelAccountingItemResponse))]
        [ApiNotFound]
        [ApiConflict]
        [ApiNotAcceptable]
        public async Task<IActionResult> Edit(FuelAccountingItemRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var fuelAccountingItemRequestModel = mapper.Map<FuelAccountingItemRequestModel>(request);
            var result = await fuelAccountingItemService.EditAsync(fuelAccountingItemRequestModel, cancellationToken);
            return Ok(mapper.Map<FuelAccountingItemResponse>(result));
        }

        /// <summary>
        /// Удалить накладную по id
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk]
        [ApiNotFound]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await fuelAccountingItemService.DeleteAsync(id, cancellationToken);
            return Ok();
        }


        /// <summary>
        /// Отправляет сформированный PDF документ по id
        /// </summary>
        [HttpGet("document{id:guid}")]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk]
        [ApiNotFound]
        public async Task<IActionResult> GetDocumentById(Guid id, CancellationToken cancellationToken)
        {
            var path = webHostEnvironment.WebRootPath + "/Document.html";
            var document = await fuelAccountingItemService.GetDocumentById(id, path, cancellationToken);
            return File(document, "application/pdf", "Document.pdf");
        }
    }
}
