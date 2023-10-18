using Cargo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cargi.Services
{
    public interface ICargoWebService
    {
        Task<IEnumerable<Courier>> GetCouriers();
        Task<IEnumerable<CargoRequest>> GetCargoRequests();
        Task CreateCargoRequest(Cargo.Models.Cargo cargo, Client sender, Client recipient, string adress);
        Task DeleteCargoRequest(long id);
        Task UpdateCargoRequest(CargoRequest cargoRequest);
        Task SubmittCargoRequest(long courierId, long cargoId, long cargoRequestId);
    }
}
