namespace CargoWeb.DTOs
{
    public class CargoRequestBody
    {
        /// <summary>
        /// Груз
        /// </summary>
        public CargoDto Cargo { get; set; }
        /// <summary>
        /// Отправитель
        /// </summary>
        public ClientDto Sender { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public ClientDto Recipient { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }
    }
}
