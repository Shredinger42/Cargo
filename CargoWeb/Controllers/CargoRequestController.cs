using AutoMapper;
using CargoWeb.DTOs;
using CargoWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Controllers
{
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

        [HttpGet]
        public async Task<IEnumerable<CargoRequestDto>> Get()
        {
            var result = await _cargoRequestService.GetAllCargoRequestsAsync();
            var resultDto = _mapper.Map<IEnumerable<CargoRequestDto>>(result);
            return resultDto;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CargoRequestBody body)
        {
            var result = await _cargoRequestService.CreateCargoRequestAsync(body);
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) 
        {
            var result = await _cargoRequestService.DeleteCargoRequestAsync(id);
            return result ? Ok() : BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CargoRequestDto cargoRequestDto)
        {
            var result = await _cargoRequestService.UpdateCargoRequestAsync(cargoRequestDto);
            return result? Ok() : BadRequest();
        }

        [HttpPost("submitt")]
        public async Task<IActionResult> SubmittCargoRequest([FromBody] SubmittCargoRequestDto body)
        {
            var result = await _cargoRequestService.SubmittCargoRequest(body);
            return result? Ok() : BadRequest();
        }
    }
}
