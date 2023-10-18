using CargoWeb.Models;

namespace CargoWeb.DTOs
{
    public class SubmittCargoRequestDto
    {
        public long CargoRequestId { get; set; }
        public long CourierId { get; set; }
        public long CargoId { get; set; }
    }
}
