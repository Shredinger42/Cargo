using CargoWeb.DbModels;
using System.Collections.Generic;

namespace CargoWeb.Models
{
    public class Courier
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Cargo> CargoToDeliver { get; set; }
    }
}
