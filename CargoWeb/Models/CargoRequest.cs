namespace CargoWeb.Models
{
    public class CargoRequest
    {
        public long Id { get; set; }
        public Client Sender { get; set; }
        public Client Recipient { get; set; }
        public Courier Courier { get; set; }
        public Cargo Cargo { get; set; }
        public string Adress { get; set; }
        public CargoState State { get; set; }
    }
}
