using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Infrastructures.Validator;
using FuelAccounting.API.Models;
using FuelAccounting.API.ModelsRequest.User;
using FuelAccounting.Services.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с пользователями
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "User")]

    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="UserController"/>
        /// </summary>
        public UserController(IUserService userService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<UserResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await userService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<UserResponse>>(result));
        }

        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(UserResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await userService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<UserResponse>(item));
        }

        /// <summary>
        /// Создаёт нового пользователя
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(UserResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var userRequestModel = mapper.Map<UserRequestModel>(request);
            var result = await userService.AddAsync(userRequestModel, cancellationToken);
            return Ok(mapper.Map<UserResponse>(result));
        }

        /// <summary>
        /// Редактирует пользователя
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(UserResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(UserRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var userRequestModel = mapper.Map<UserRequestModel>(request);
            var result = await userService.EditAsync(userRequestModel, cancellationToken);
            return Ok(mapper.Map<UserResponse>(result));
        }

        /// <summary>
        /// Удаляет пользователя по id
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await userService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
