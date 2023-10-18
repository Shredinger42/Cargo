using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public interface IClientRepository
    {
        Task<ClientDb> AddAsync(Client client);
    }
}
