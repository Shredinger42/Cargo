namespace Cargo.DTOs
{
    public class CargoRequestDto
    {
        /// <summary>
        /// id заявки
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// отправитель
        /// </summary>
        public ClientDto Sender { get; set; }
        /// <summary>
        /// получатель
        /// </summary>
        public ClientDto Recipient { get; set; }
        /// <summary>
        /// курьер
        /// </summary>
        public CourierDto Courier { get; set; }
        /// <summary>
        /// груз
        /// </summary>
        public CargoDto Cargo { get; set; }
        /// <summary>
        /// адрес
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Состояние заявки
        /// </summary>
        public CargoStateDto State { get; set; }
    }
}
