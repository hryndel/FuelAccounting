﻿using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.FuelStation;
using FuelAccounting.Context.Contracts.Enums;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с АЗС
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "FuelStation")]
    public class FuelStationController : ControllerBase
    {
        private readonly IFuelStationService fuelStationService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelStationController"/>
        /// </summary>
        public FuelStationController(IFuelStationService fuelStationService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.fuelStationService = fuelStationService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех АЗС
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(IEnumerable<FuelStationResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await fuelStationService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<FuelStationResponse>>(result));
        }

        /// <summary>
        /// Получить АЗС по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [Authorize(Roles = $"{nameof(UserTypes.Employee)}, {nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelStationResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await fuelStationService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<FuelStationResponse>(item));
        }

        /// <summary>
        /// Создать новую АЗС
        /// </summary>
        [HttpPost]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelStationResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateFuelStationRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var fuelStationRequestModel = mapper.Map<FuelStationRequestModel>(request);
            var result = await fuelStationService.AddAsync(fuelStationRequestModel, cancellationToken);
            return Ok(mapper.Map<FuelStationResponse>(result));
        }

        /// <summary>
        /// Редактировать АЗС
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk(typeof(FuelStationResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(FuelStationRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var fuelStationRequestModel = mapper.Map<FuelStationRequestModel>(request);
            var result = await fuelStationService.EditAsync(fuelStationRequestModel, cancellationToken);
            return Ok(mapper.Map<FuelStationResponse>(result));
        }

        /// <summary>
        /// Удалить АЗС по id
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{nameof(UserTypes.Manager)}, {nameof(UserTypes.Administrator)}")]
        [ApiOk]
        [ApiNotFound]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await fuelStationService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
