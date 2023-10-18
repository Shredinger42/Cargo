namespace Cargo.DTOs
{
    public class CargoRequestDto
    {
        public long Id { get; set; }
        public ClientDto Sender { get; set; }
        public ClientDto Recipient { get; set; }
        public CourierDto Courier { get; set; }
        public CargoDto Cargo { get; set; }
        public string Adress { get; set; }
        public CargoStateDto State { get; set; }
    }
}
