using CargoWeb.DTOs;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Services
{
    public interface ICargoRequestService
    {
        Task<bool> CreateCargoRequestAsync(CargoRequestBody body);
        Task<IEnumerable<CargoRequest>> GetAllCargoRequestsAsync();
        Task<bool> UpdateCargoRequestAsync(CargoRequestDto cargoRequestDto);
        Task<bool> DeleteCargoRequestAsync(long id);
        Task<bool> SubmittCargoRequest(SubmittCargoRequestDto body);
    }
}
