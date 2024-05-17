using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.Trailer;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с полуприцепами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Trailer")]

    public class TrailerController : ControllerBase
    {
        private readonly ITrailerService trailerService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TrailerController"/>
        /// </summary>
        public TrailerController(ITrailerService trailerService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.trailerService = trailerService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех полуприцепов
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<TrailerResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await trailerService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<TrailerResponse>>(result));
        }

        /// <summary>
        /// Получает полуприцеп по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(TrailerResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await trailerService.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return NotFound($"Не удалось найти полуприцеп с идентификатором {id}");
            }
            return Ok(mapper.Map<TrailerResponse>(item));
        }

        /// <summary>
        /// Создаёт новый полуприцеп
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(TrailerResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateTrailerRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var trailerRequestModel = mapper.Map<TrailerRequestModel>(request);
            var result = await trailerService.AddAsync(trailerRequestModel, cancellationToken);
            return Ok(mapper.Map<TrailerResponse>(result));
        }

        /// <summary>
        /// Редактирует полуприцеп
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(TrailerResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(TrailerRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var trailerRequestModel = mapper.Map<TrailerRequestModel>(request);
            var result = await trailerService.EditAsync(trailerRequestModel, cancellationToken);
            return Ok(mapper.Map<TrailerResponse>(result));
        }

        /// <summary>
        /// Удаляет полуприцеп по id
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await trailerService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
