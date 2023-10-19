using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    /// <summary>
    /// Репозиторий для работы с заявками
    /// </summary>
    public interface ICargoRequestRepository
    {
        /// <summary>
        /// Получение всех заявок
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CargoRequestDb>> GetAllAsync();
        
        /// <summary>
        /// Получение заявки по id
        /// </summary>
        /// <param name="id">id заявки</param>
        /// <returns>Возвращает заявку</returns>
        Task<CargoRequestDb> GetByIdAsync(long id);

        /// <summary>
        /// Удаление заявки по id
        /// </summary>
        /// <param name="id">id заявки</param>
        /// <returns>Возвращает удаленную заявку</returns>
        Task<CargoRequestDb> DeleteByIdAsync(long id);

        /// <summary>
        /// Обновлает заявку
        /// </summary>
        /// <param name="cargoRequest">Данные для обновления</param>
        /// <returns>Возвращает обновленную заявку</returns>
        Task<CargoRequestDb> UpdateAsync(CargoRequest cargoRequest);

        /// <summary>
        /// Добавлеяет новую заявку
        /// </summary>
        /// <param name="cargoRequest">Заявка для добавления</param>
        /// <returns>Возвращает добавленную заявку</returns>
        Task<CargoRequestDb> AddAsync(CargoRequest cargoRequest);
    }
}
