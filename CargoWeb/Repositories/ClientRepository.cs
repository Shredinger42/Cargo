using AutoMapper;
using CargoWeb.DbModels;
using CargoWeb.Models;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationContext _db;
        private readonly IMapper _mapper;

        public ClientRepository(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ClientDb> AddAsync(Client client)
        {
            var clientDb = _mapper.Map<ClientDb>(client);
            var result = await _db.Clients.AddAsync(clientDb);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
    }
}
