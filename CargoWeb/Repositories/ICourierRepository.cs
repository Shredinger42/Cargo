using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public interface ICourierRepository
    {
        Task<IEnumerable<CourierDb>> GetAllAsync();
        Task<CourierDb> GetByIdAsync(long id);
        Task<CourierDb> AddAsync(Courier courier);
        Task UpdateAsync(Courier courier);
    }
}
