using SkiShop.Models;

namespace Backend.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
