using AutoMapper;
using CargoWeb.DbModels;
using CargoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private ApplicationContext _db;
        private readonly IMapper _mapper;

        public CargoRepository(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CargoDb> AddAsync(Cargo cargo)
        {
            var cargoDb = _mapper.Map<CargoDb>(cargo);
            var result = await _db.Cargos.AddAsync(cargoDb);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CargoDb> GetByIdAsync(long id)
        {
            return await _db.Cargos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
