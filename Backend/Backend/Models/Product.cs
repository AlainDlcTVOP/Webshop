namespace SkiShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; } // Navigation property
        public double Price { get; set; }
        public int InStock { get; set; }
    }
}
