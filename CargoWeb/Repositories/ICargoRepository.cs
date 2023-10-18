using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public interface ICargoRepository
    {
        Task<CargoDb> AddAsync(Cargo cargo);

        Task<CargoDb> GetByIdAsync(long id);
    }
}
