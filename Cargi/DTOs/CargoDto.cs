namespace Cargo.DTOs
{
    public class CargoDto
    {
        /// <summary>
        /// id груза
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// наименование груза
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// вес груза
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Цена груза
        /// </summary>
        public decimal Price { get; set; }
    }
}
