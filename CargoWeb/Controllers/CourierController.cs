using AutoMapper;
using CargoWeb.DTOs;
using CargoWeb.Models;
using CargoWeb.Services;
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
        public async Task<IEnumerable<CourierDto>> Get()
        {
            var result = await _courierService.GetAllCouriersAsync();
            var resultDto = _mapper.Map<IEnumerable<CourierDto>>(result);
            return resultDto;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CourierDto courier)
        {
            var result = await _courierService.CreateCourierAsync(courier);
            return result ? Ok() : BadRequest();
        }
    }
}
