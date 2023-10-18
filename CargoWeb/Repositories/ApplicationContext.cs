using CargoWeb.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CargoWeb.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CargoDb> Cargos { get; set; }
        public DbSet<CargoRequestDb> CargosRequests { get; set; }
        public DbSet<ClientDb> Clients { get; set; }
        public DbSet<CourierDb> Couriers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
