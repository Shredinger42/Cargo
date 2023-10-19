using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public interface ICargoRequestRepository
    {
        Task<IEnumerable<CargoRequestDb>> GetAllAsync();
        
        Task<CargoRequestDb> GetByIdAsync(long id);

        Task<CargoRequestDb> DeleteByIdAsync(long id);

        Task<CargoRequestDb> UpdateAsync(CargoRequest cargoRequest);

        Task<CargoRequestDb> AddAsync(CargoRequest cargoRequest);
    }
}
