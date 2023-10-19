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
        /// <inheritdoc />
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
        /// <inheritdoc />
        public async Task<CargoRequestDb> GetByIdAsync(long id)
        {
            return await _db.CargosRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <inheritdoc />
        public async Task<CargoRequestDb> DeleteByIdAsync(long id)
        {
            var cargoRequestDb = new CargoRequestDb() { Id = id};
            _db.CargosRequests.Attach(cargoRequestDb);
            var deletedRequest = _db.CargosRequests.Remove(cargoRequestDb);
            await _db.SaveChangesAsync();
            return deletedRequest.Entity;
        }
        /// <inheritdoc />
        public async Task<CargoRequestDb> UpdateAsync(CargoRequest cargoRequest)
        {
            var cargoRequestDb = _mapper.Map<CargoRequestDb>(cargoRequest);
            var updatedRequest = _db.CargosRequests.Update(cargoRequestDb);
            await _db.SaveChangesAsync();
            return updatedRequest.Entity;
        }
        /// <inheritdoc />
        public async Task<CargoRequestDb> AddAsync(CargoRequest cargoRequest)
        {
            var cargoRequestDb = _mapper.Map<CargoRequestDb>(cargoRequest);
            var addedRequest = await _db.CargosRequests.AddAsync(cargoRequestDb);
            await _db.SaveChangesAsync();
            return addedRequest.Entity;
        }
    }
}
