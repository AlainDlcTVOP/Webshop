using SkiShop.Models;

namespace Backend.Models
{
    public class BasketItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public double TotalPrice()
        {
            return Quantity * Product.Price;
        }

    }

}
