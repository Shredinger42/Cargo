using CargoWeb.Models;

namespace CargoWeb.DTOs
{
    public class SubmittCargoRequestDto
    {
        /// <summary>
        /// id заявки
        /// </summary>
        public long CargoRequestId { get; set; }
        /// <summary>
        /// id курьера
        /// </summary>
        public long CourierId { get; set; }
        /// <summary>
        /// id груза
        /// </summary>
        public long CargoId { get; set; }
    }
}
