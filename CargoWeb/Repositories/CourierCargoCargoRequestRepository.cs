using CargoWeb.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Repositories
{
    public class CourierCargoCargoRequestRepository : ICourierCargoCargoRequestRepository
    {
        private readonly ApplicationContext _db;

        public CourierCargoCargoRequestRepository(ApplicationContext db)
        {
            this._db = db;
        }
        /// <inheritdoc />
        public async Task<CargoRequestDb> Update(long courierId, long cargoId, long cargoRequestId)
        {
            using (var transaction = _db.Database.BeginTransaction()) 
            {
                try
                {
                    var cargoDb = await _db.Cargos.FirstOrDefaultAsync(x => x.Id == cargoId);
                    var courierDb = await _db.Couriers.FirstOrDefaultAsync(x => x.Id == courierId);
                    var cargoRequestDb = await _db.CargosRequests.FirstOrDefaultAsync(x => x.Id == cargoRequestId);
                    courierDb.CargoToDeliver ??= new List<CargoDb>();
                    courierDb.CargoToDeliver.Add(cargoDb);
                    cargoRequestDb.Courier = courierDb;
                    cargoRequestDb.State = CargoStateDb.Submitted;
                    var updatedCargoRequest = _db.CargosRequests.Update(cargoRequestDb);
                    _db.SaveChanges();
                    transaction.Commit();
                    return updatedCargoRequest.Entity;
                }
                catch
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }
    }
}
