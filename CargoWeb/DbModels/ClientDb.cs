using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoWeb.DbModels
{
    public class ClientDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        /// <summary>
        /// Id клиента
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Наименование клиента
        /// </summary>
        public string Name { get; set; }
    }
}
