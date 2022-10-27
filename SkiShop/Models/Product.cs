namespace SkiShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Description { get; set; }
        public string[] Pictures { get; set; }
        public double SalePrice { get; set; }
        public int InStock { get; set; }
    }
}
