using AutoMapper;
using CargoWeb.DTOs;
using CargoWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Controllers
{
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

        [HttpGet] 
        public async Task<ActionResult> Get()
        {
            var result = await _courierService.GetAllCouriersAsync();
            if (result is null) return StatusCode(StatusCodes.Status500InternalServerError);
            var resultDto = _mapper.Map<IEnumerable<CourierDto>>(result);
            return Ok(resultDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CourierDto courier)
        {
            var result = await _courierService.CreateCourierAsync(courier);
            return result is not null ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
