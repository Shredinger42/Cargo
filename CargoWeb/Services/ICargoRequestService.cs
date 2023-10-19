using CargoWeb.DTOs;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Services
{
    /// <summary>
    /// Сервис для работы с заявками
    /// </summary>
    public interface ICargoRequestService
    {
        /// <summary>
        /// Создает заявку
        /// </summary>
        /// <param name="body">Тело заявки</param>
        /// <returns>Возвращает созданную заявку</returns>
        Task<CargoRequest> CreateCargoRequestAsync(CargoRequestBody body);
        /// <summary>
        /// Получение всех заявок
        /// </summary>
        /// <returns>Список заявок</returns>
        Task<IEnumerable<CargoRequest>> GetAllCargoRequestsAsync();
        /// <summary>
        /// Обновление заявки
        /// </summary>
        /// <param name="cargoRequestDto">Данные заявки</param>
        /// <returns>Возвращает обновленную заявку</returns>
        Task<CargoRequest> UpdateCargoRequestAsync(CargoRequestDto cargoRequestDto);
        /// <summary>
        /// Удаление заявки по id
        /// </summary>
        /// <param name="id">id заявки</param>
        /// <returns>Возвращает удаленную заявку</returns>
        Task<CargoRequest> DeleteCargoRequestAsync(long id);
        /// <summary>
        /// Передает заявку на выполнение
        /// </summary>
        /// <param name="body">Информация по передачи заявки на выполнение</param>
        /// <returns>Возвращает переданную заявку</returns>
        Task<CargoRequest> SubmittCargoRequest(SubmittCargoRequestDto body);
    }
}
