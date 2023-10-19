using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    /// <summary>
    /// Репозиторий для работы с грузами
    /// </summary>
    public interface ICargoRepository
    {
        /// <summary>
        /// Добавление нового груза
        /// </summary>
        /// <param name="cargo">Груз</param>
        /// <returns></returns>
        Task<CargoDb> AddAsync(Cargo cargo);

        /// <summary>
        /// Получение груза по id
        /// </summary>
        /// <param name="id">id груза</param>
        /// <returns></returns>
        Task<CargoDb> GetByIdAsync(long id);
    }
}
