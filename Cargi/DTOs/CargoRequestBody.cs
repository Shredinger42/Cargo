namespace Cargo.DTOs
{
    public class CargoRequestBody
    {
        public CargoDto Cargo { get; set; }

        public ClientDto Sender { get; set; }

        public ClientDto Recipient { get; set; }

        public string Adress { get; set; }
    }
}
