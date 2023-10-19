using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoWeb.DbModels
{
    public class CargoDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        /// <summary>
        /// id Груза
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование груза
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Вес груза
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Цена груза
        /// </summary>
        public decimal Price { get; set; }
    }
}
