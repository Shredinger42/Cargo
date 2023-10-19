using Cargo.DTOs;
using System.Collections.Generic;
namespace Cargo.DTOs
{
    public class CourierDto
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
        /// Список грузов для доставки
        /// </summary>
        public List<CargoDto> CargoToDeliver { get; set; }
    }
}
