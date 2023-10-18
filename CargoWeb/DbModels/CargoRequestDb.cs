using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoWeb.DbModels
{
    public class CargoRequestDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public ClientDb Sender { get; set; }
        public ClientDb Recipient { get; set; }
        public CourierDb Courier { get; set; }
        public CargoDb Cargo { get; set; }
        public string Adress { get; set; }
        public CargoStateDb State { get; set; }
    }
}
