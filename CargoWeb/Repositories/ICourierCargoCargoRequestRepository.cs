using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public interface ICourierCargoCargoRequestRepository
    {
        Task<bool> Update(long courierId, long cargoId, long cargoRequestId);
    }
}
