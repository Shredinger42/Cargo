using CargoWeb.DbModels;
using System.Collections.Generic;

namespace CargoWeb.Models
{
    public class Courier
    {
        /// <summary>
        /// id курьера
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// наименование курьера
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список грузов курьера к доставке
        /// </summary>
        public List<Cargo> CargoToDeliver { get; set; }
    }
}
