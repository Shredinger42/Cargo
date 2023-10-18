using AutoMapper;
using CargoWeb.DbModels;
using CargoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public class CargoRequestRepository : ICargoRequestRepository
    {
        private ApplicationContext _db;
        private readonly IMapper _mapper;

        public CargoRequestRepository(ApplicationContext db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CargoRequestDb>> GetAllAsync()
        {
            var cargoRequestsDb = await _db.CargosRequests
                .Include(x => x.Cargo)
                .Include(x => x.Sender)
                .Include(x => x.Recipient)
                .Include(x => x.Courier)
                .ToListAsync();

            return cargoRequestsDb;
        }

        public async Task<CargoRequestDb> GetByIdAsync(long id)
        {
            return await _db.CargosRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteByIdAsync(long id)
        {
            var cargoRequestDb = new CargoRequestDb() { Id = id};
            _db.CargosRequests.Attach(cargoRequestDb);
            _db.CargosRequests.Remove(cargoRequestDb);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(CargoRequest cargoRequest)
        {
            var cargoRequestDb = _mapper.Map<CargoRequestDb>(cargoRequest);
            _db.CargosRequests.Update(cargoRequestDb);
            await _db.SaveChangesAsync();
        }

        public async Task AddAsync(CargoRequest cargoRequest)
        {
            var cargoRequestDb = _mapper.Map<CargoRequestDb>(cargoRequest);
            await _db.CargosRequests.AddAsync(cargoRequestDb);
            await _db.SaveChangesAsync();
        }
    }
}
