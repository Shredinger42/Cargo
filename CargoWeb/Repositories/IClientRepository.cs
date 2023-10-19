using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    /// <summary>
    /// Репозиторий для работы с клиентом
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Добавляет нового клиента
        /// </summary>
        /// <param name="client">Клиент для добавления</param>
        /// <returns>Возвращает добавленного клиента</returns>
        Task<ClientDb> AddAsync(Client client);
    }
}
