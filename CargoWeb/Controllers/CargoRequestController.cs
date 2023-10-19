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
        public async Task<ActionResult> Get()
        {
            var result = await _cargoRequestService.GetAllCargoRequestsAsync();
            if (result is null) StatusCode(StatusCodes.Status500InternalServerError);
            var resultDto = _mapper.Map<IEnumerable<CargoRequestDto>>(result);
            return Ok(resultDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CargoRequestBody body)
        {
            var result = await _cargoRequestService.CreateCargoRequestAsync(body);
            return result is not null? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) 
        {
            var result = await _cargoRequestService.DeleteCargoRequestAsync(id);
            return result is not null ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CargoRequestDto cargoRequestDto)
        {
            var result = await _cargoRequestService.UpdateCargoRequestAsync(cargoRequestDto);
            return result is not null ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("submitt")]
        public async Task<IActionResult> SubmittCargoRequest([FromBody] SubmittCargoRequestDto body)
        {
            var result = await _cargoRequestService.SubmittCargoRequest(body);
            return result is not null ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
