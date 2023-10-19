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
    /// Сервис для работы с курьерами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CourierController : ControllerBase
    {
        private readonly ICourierService _courierService;
        private readonly IMapper _mapper;

        public CourierController(ICourierService courierService, IMapper mapper)
        {
            _courierService = courierService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всех курьеров
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Список курьеров", typeof(IEnumerable<CourierDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server Error", typeof(int))]

        [HttpGet] 
        public async Task<ActionResult> Get()
        {
            var result = await _courierService.GetAllCouriersAsync();
            if (result is null) return StatusCode(StatusCodes.Status500InternalServerError);
            var resultDto = _mapper.Map<IEnumerable<CourierDto>>(result);
            return Ok(resultDto);
        }

        /// <summary>
        /// Создание курьера
        /// </summary>
        /// <param name="courier">Данные курьера</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Информация о том что курьер был создан", typeof(int))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server Error", typeof(int))]
        [HttpPost]
        public async Task<IActionResult> Post(CourierDto courier)
        {
            var result = await _courierService.CreateCourierAsync(courier);
            return result is not null ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
