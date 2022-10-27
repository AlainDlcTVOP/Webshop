namespace SkiShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
    }
}
