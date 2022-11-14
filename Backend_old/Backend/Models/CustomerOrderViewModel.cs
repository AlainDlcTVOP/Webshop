using SkiShop.Models;

namespace Backend.Models
{
    public class CustomerOrderViewModel
    {
        public Order Order { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
