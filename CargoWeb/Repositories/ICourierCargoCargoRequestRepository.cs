using CargoWeb.DbModels;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public interface ICourierCargoCargoRequestRepository
    {
        Task<CargoRequestDb> Update(long courierId, long cargoId, long cargoRequestId);
    }
}
