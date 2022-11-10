using SkiShop.Models;

namespace Backend.Models
{
    public class CartContent
    {
        public int CartContentId { get; set; }
        public int TotalCost { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
