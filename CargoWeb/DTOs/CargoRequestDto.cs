using CargoWeb.DbModels;
using System.Text.Json.Serialization;

namespace CargoWeb.DTOs
{
    public class CargoRequestDto
    {
        /// <summary>
        /// Id заявки
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Отправитель
        /// </summary>
        public ClientDto Sender { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public ClientDto Recipient { get; set; }
        /// <summary>
        /// Курьер
        /// </summary>
        public CourierDto Courier { get; set; }
        /// <summary>
        /// Груз
        /// </summary>
        public CargoDto Cargo { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Статус заявки
        /// </summary>
        public CargoStateDto State { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

    }
}
