using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoWeb.DbModels
{
    public class CourierDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        /// <summary>
        ///  Id курьера
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Наименование курьера
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список грузов курьера к доставке
        /// </summary>
        public List<CargoDb> CargoToDeliver { get; set; } = new List<CargoDb>();
    }
}
