using Cargo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cargi.Services
{
    /// <summary>
    /// Сервис для получения данных 
    /// </summary>
    public interface ICargoWebService
    {
        /// <summary>
        /// Получение списка курьеров
        /// </summary>
        /// <returns>Список курьеров</returns>
        Task<IEnumerable<Courier>> GetCouriers();
        /// <summary>
        /// Получение списка заявок
        /// </summary>
        /// <returns>Список заявок</returns>
        Task<IEnumerable<CargoRequest>> GetCargoRequests();
        /// <summary>
        /// Создает новую заявку
        /// </summary>
        /// <param name="cargo">Груз</param>
        /// <param name="sender">Отправитель</param>
        /// <param name="recipient">Получатель</param>
        /// <param name="adress">Адрес доставки</param>
        /// <returns></returns>
        Task CreateCargoRequest(Cargo.Models.Cargo cargo, Client sender, Client recipient, string adress);
        /// <summary>
        /// Удаляет заявку по id
        /// </summary>
        /// <param name="id">id заявки</param>
        /// <returns></returns>
        Task DeleteCargoRequest(long id);
        /// <summary>
        /// Обновляет заявку
        /// </summary>
        /// <param name="cargoRequest">Заявка для обновления</param>
        /// <returns></returns>
        Task UpdateCargoRequest(CargoRequest cargoRequest);
        /// <summary>
        /// Передача заявки на выполнение
        /// </summary>
        /// <param name="courierId">id курьера на которого передается заявка</param>
        /// <param name="cargoId">id груза</param>
        /// <param name="cargoRequestId">id заявки</param>
        /// <returns></returns>
        Task SubmittCargoRequest(long courierId, long cargoId, long cargoRequestId);
    }
}
