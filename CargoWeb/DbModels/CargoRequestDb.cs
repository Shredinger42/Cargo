using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoWeb.DbModels
{
    public class CargoRequestDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        /// <summary>
        /// Id заявки
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Отправитель заявки
        /// </summary>
        public ClientDb Sender { get; set; }
        /// <summary>
        /// Получатель заявки
        /// </summary>
        public ClientDb Recipient { get; set; }
        /// <summary>
        /// Курьер
        /// </summary>
        public CourierDb Courier { get; set; }
        /// <summary>
        /// Груз
        /// </summary>
        public CargoDb Cargo { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Состояние заявки
        /// </summary>
        public CargoStateDb State { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

    }
}
