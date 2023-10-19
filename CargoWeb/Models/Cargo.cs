namespace CargoWeb.Models
{
    public class Cargo
    {
        /// <summary>
        /// id груза
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование груза
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Вес груза
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Цена груза
        /// </summary>
        public decimal Price { get; set; }
    }
}
