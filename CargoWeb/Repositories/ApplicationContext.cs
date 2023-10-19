using CargoWeb.DbModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CargoWeb.Repositories
{
    /// <summary>
    /// Контект для работы с базой данных
    /// </summary>
    public class ApplicationContext : DbContext
    {
        public DbSet<CargoDb> Cargos { get; set; }
        public DbSet<CargoRequestDb> CargosRequests { get; set; }
        public DbSet<ClientDb> Clients { get; set; }
        public DbSet<CourierDb> Couriers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Cargo.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);

        }
    }
}
