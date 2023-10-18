using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoWeb.DbModels
{
    public class CourierDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public List<CargoDb> CargoToDeliver { get; set; } = new List<CargoDb>();
    }
}
