namespace CargoWeb.Models
{
    public class CargoRequest
    {
        /// <summary>
        /// id заявки
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Отправитель
        /// </summary>
        public Client Sender { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public Client Recipient { get; set; }
        /// <summary>
        /// Курьер
        /// </summary>
        public Courier Courier { get; set; }
        /// <summary>
        /// Груз
        /// </summary>
        public Cargo Cargo { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Состояние заявки
        /// </summary>
        public CargoState State { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
    }
}
