using System.Text.Json.Serialization;

namespace CargoWeb.DTOs
{
    public class ClientDto
    {
        /// <summary>
        /// id Клиента
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Наименование клиента
        /// </summary>
        public string Name { get; set; }
    }
}
