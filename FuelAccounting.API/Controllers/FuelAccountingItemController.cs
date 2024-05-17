﻿using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.FuelAccountingItem;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
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

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelAccountingItemController"/>
        /// </summary>
        public FuelAccountingItemController(IFuelAccountingItemService fuelAccountingItemService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.fuelAccountingItemService = fuelAccountingItemService;
            this.mapper = mapper;
            this.validatorService = validatorService;
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
    }
}
