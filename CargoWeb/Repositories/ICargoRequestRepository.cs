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

        Task DeleteByIdAsync(long id);

        Task UpdateAsync(CargoRequest cargoRequest);

        Task AddAsync(CargoRequest cargoRequest);
    }
}
