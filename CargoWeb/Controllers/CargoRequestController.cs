using AutoMapper;
using CargoWeb.DTOs;
using CargoWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CargoWeb.Controllers
{
    /// <summary>
    /// Сервис для работы с заявками
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CargoRequestController : ControllerBase
    {
        private readonly ICargoRequestService _cargoRequestService;
        private readonly IMapper _mapper;

        public CargoRequestController(ICargoRequestService cargoRequestService, IMapper mapper)
        {
            _cargoRequestService = cargoRequestService;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод получения всех заявок
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Список заявок", typeof(IEnumerable<CargoRequestDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server Error", typeof(int))]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _cargoRequestService.GetAllCargoRequestsAsync();
            if (result is null) StatusCode(StatusCodes.Status500InternalServerError);
            var resultDto = _mapper.Map<IEnumerable<CargoRequestDto>>(result);
            return Ok(resultDto);
        }

        /// <summary>
        /// Метод создания новой заявки
        /// </summary>
        /// <param name="body">Содержание новой заявки</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Инфрмация что заявка создалась", typeof(int))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server Error", typeof(int))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CargoRequestBody body)
        {
            var result = await _cargoRequestService.CreateCargoRequestAsync(body);
            return result is not null? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Удаление заявки
        /// </summary>
        /// <param name="id">Id заявки которую нужно удалить</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Инфрмация что заявка удалилась", typeof(int))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server Error", typeof(int))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) 
        {
            var result = await _cargoRequestService.DeleteCargoRequestAsync(id);
            return result is not null ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Обновление заявки
        /// </summary>
        /// <param name="cargoRequestDto">Какие данные необходимо обновить</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Инфрмация что заявка обновилась", typeof(int))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server Error", typeof(int))]
        [HttpPost("update")]
        public async Task<IActionResult> Update(CargoRequestDto cargoRequestDto)
        {
            var result = await _cargoRequestService.UpdateCargoRequestAsync(cargoRequestDto);
            return result is not null ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Передача заявки на выполнение
        /// </summary>
        /// <param name="body">Id заявки, id курьера и id груза</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Инфрмация что заявка была передана на выполнение", typeof(int))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server Error", typeof(int))]
        [HttpPost("submitt")]
        public async Task<IActionResult> SubmittCargoRequest([FromBody] SubmittCargoRequestDto body)
        {
            var result = await _cargoRequestService.SubmittCargoRequest(body);
            return result is not null ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
