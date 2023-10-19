using AutoMapper;
using CargoWeb.DbModels;
using CargoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public class CourierRepository : ICourierRepository
    {
        private ApplicationContext _db;
        private readonly IMapper _mapper;

        public CourierRepository(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        /// <inheritdoc />
        public async Task<CourierDb> AddAsync(Courier courier)
        {
            var courierDb = _mapper.Map<CourierDb>(courier);
            var result = await _db.Couriers.AddAsync(courierDb);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
        /// <inheritdoc />
        public async Task<IEnumerable<CourierDb>> GetAllAsync()
        {
            var cargoRequestsDb = await _db.Couriers.Include(x => x.CargoToDeliver).ToListAsync();
            return cargoRequestsDb;

        }
        /// <inheritdoc />
        public async Task UpdateAsync(Courier courier)
        {
            var courierDb = _mapper.Map<CourierDb>(courier);
            _db.Couriers.Update(courierDb);
            await _db.SaveChangesAsync();
        }
        /// <inheritdoc />
        public async Task<CourierDb> GetByIdAsync(long id)
        {
            return await _db.Couriers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
