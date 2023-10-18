using Cargo.DTOs;
using System.Collections.Generic;
namespace Cargo.DTOs
{
    public class CourierDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<CargoDto> CargoToDeliver { get; set; }
    }
}
