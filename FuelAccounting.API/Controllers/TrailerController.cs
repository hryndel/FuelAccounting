using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.Trailer;
using FuelAccounting.Context.Contracts.Enums;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using FuelAccounting.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(IEnumerable<TrailerResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await trailerService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<TrailerResponse>>(result));
        }

        /// <summary>
        /// Получить список свободных полуприцепов
        /// </summary>
        [HttpGet("free")]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(IEnumerable<TrailerResponse>))]
        public async Task<IActionResult> GetFreeAll(CancellationToken cancellationToken)
        {
            var result = await trailerService.GetFreeAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<TrailerResponse>>(result));
        }

        /// <summary>
        /// Получить полуприцеп по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
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
        /// Создать новый полуприцеп
        /// </summary>
        [HttpPost]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
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
        /// Редактировать полуприцеп
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
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
        /// Удалить полуприцеп по id
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
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
