using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.FuelAccountingItem;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore;
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
        private readonly IConverter converter;
        private readonly IWebHostEnvironment webHostEnvironment;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelAccountingItemController"/>
        /// </summary>
        public FuelAccountingItemController(IFuelAccountingItemService fuelAccountingItemService, 
            IMapper mapper, 
            IApiValidatorService validatorService,
            IConverter converter,
            IWebHostEnvironment webHostEnvironment)
        {
            this.fuelAccountingItemService = fuelAccountingItemService;
            this.mapper = mapper;
            this.validatorService = validatorService;
            this.converter = converter;
            this.webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Получить список всех накладных
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<FuelAccountingItemResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await fuelAccountingItemService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<FuelAccountingItemResponse>>(result));
        }

        /// <summary>
        /// Получает накладную по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(FuelAccountingItemResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await fuelAccountingItemService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<FuelAccountingItemResponse>(item));
        }

        /// <summary>
        /// Создаёт новую накладную
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(FuelAccountingItemResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateFuelAccountingItemRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var fuelAccountingItemRequestModel = mapper.Map<FuelAccountingItemRequestModel>(request);
            var result = await fuelAccountingItemService.AddAsync(fuelAccountingItemRequestModel, cancellationToken);
            return Ok(mapper.Map<FuelAccountingItemResponse>(result));
        }

        /// <summary>
        /// Редактирует имеющуюся накладную
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(FuelAccountingItemResponse))]
        [ApiConflict]
        [ApiNotFound]
        public async Task<IActionResult> Edit(FuelAccountingItemRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var fuelAccountingItemRequestModel = mapper.Map<FuelAccountingItemRequestModel>(request);
            var result = await fuelAccountingItemService.EditAsync(fuelAccountingItemRequestModel, cancellationToken);
            return Ok(mapper.Map<FuelAccountingItemResponse>(result));
        }

        /// <summary>
        /// Удаляет имеющуюся накладную по id
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiConflict]
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
        [ApiOk]
        public async Task<IActionResult> GetDocumentById(Guid id, CancellationToken cancellationToken)
        {
            var path = webHostEnvironment.WebRootPath + "/Document.html";
            var document = await fuelAccountingItemService.GetDocumentById(id, path, cancellationToken);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Document PDF"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = document,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = converter.Convert(pdf);
            return File(file, "application/pdf", "Document.pdf"); ;
        }
    }
}
