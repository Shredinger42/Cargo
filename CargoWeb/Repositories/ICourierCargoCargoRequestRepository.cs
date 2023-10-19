using CargoWeb.DbModels;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    /// <summary>
    /// Репозиторий для одновременной работы с курьером, грузом и заявками
    /// </summary>
    public interface ICourierCargoCargoRequestRepository
    {
        /// <summary>
        /// Обновить одновременно курьера, груз и заявку
        /// </summary>
        /// <param name="courierId">id курьера</param>
        /// <param name="cargoId"><id груза/param>
        /// <param name="cargoRequestId">id заявки</param>
        /// <returns>Возврщает обновленную заявку</returns>
        Task<CargoRequestDb> Update(long courierId, long cargoId, long cargoRequestId);
    }
}
