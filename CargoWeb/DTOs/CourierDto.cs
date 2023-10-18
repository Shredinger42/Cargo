using CargoWeb.DbModels;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CargoWeb.DTOs
{
    public class CourierDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<CargoDto> CargoToDeliver { get; set; }
    }
}
