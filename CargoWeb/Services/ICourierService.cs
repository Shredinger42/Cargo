using CargoWeb.DTOs;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Services
{
    /// <summary>
    /// Сервис для работы с курьерами
    /// </summary>
    public interface ICourierService
    {
        /// <summary>
        /// Создание курьера
        /// </summary>
        /// <param name="courierDto">Данные курьера</param>
        /// <returns>Возвращает созданного курьера</returns>
        Task<Courier> CreateCourierAsync(CourierDto courierDto);
        /// <summary>
        /// Получение всех курьеров
        /// </summary>
        /// <returns>Возвращает список курьеров</returns>
        Task<IEnumerable<Courier>> GetAllCouriersAsync();

    }
}
