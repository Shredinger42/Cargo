using System.Text.Json.Serialization;

namespace CargoWeb.DTOs
{
    public class CargoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }
    }
}
