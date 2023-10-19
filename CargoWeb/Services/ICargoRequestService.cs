using CargoWeb.DTOs;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Services
{
    public interface ICargoRequestService
    {
        Task<CargoRequest> CreateCargoRequestAsync(CargoRequestBody body);
        Task<IEnumerable<CargoRequest>> GetAllCargoRequestsAsync();
        Task<CargoRequest> UpdateCargoRequestAsync(CargoRequestDto cargoRequestDto);
        Task<CargoRequest> DeleteCargoRequestAsync(long id);
        Task<CargoRequest> SubmittCargoRequest(SubmittCargoRequestDto body);
    }
}
