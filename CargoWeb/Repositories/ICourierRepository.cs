using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    /// <summary>
    /// Репозиторий для работы с курьерами
    /// </summary>
    public interface ICourierRepository
    {
        /// <summary>
        /// Получение всех курьеров
        /// </summary>
        /// <returns>Список курьеров</returns>
        Task<IEnumerable<CourierDb>> GetAllAsync();
        /// <summary>
        /// Получение курьера по id
        /// </summary>
        /// <param name="id">id курьера</param>
        /// <returns>Возвращает курьера</returns>
        Task<CourierDb> GetByIdAsync(long id);
        /// <summary>
        /// Добавление курьера
        /// </summary>
        /// <param name="courier">Данные курьера</param>
        /// <returns>Возвращает добавленного курьера</returns>
        Task<CourierDb> AddAsync(Courier courier);
        /// <summary>
        /// Обновляет курьера
        /// </summary>
        /// <param name="courier">Данные курьера</param>
        /// <returns>Возвращает обновленного курьера</returns>
        Task UpdateAsync(Courier courier);
    }
}
