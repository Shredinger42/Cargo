using CargoWeb.DbModels;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CargoWeb.DTOs
{
    public class CourierDto
    {
        /// <summary>
        /// id курькера
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// наименование курьера
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список грузов курьера к доставке
        /// </summary>
        public List<CargoDto> CargoToDeliver { get; set; }
    }
}
