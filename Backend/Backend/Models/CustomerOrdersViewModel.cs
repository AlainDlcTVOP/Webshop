using SkiShop.Models;

namespace Backend.Models
{
    public class CustomerOrdersViewModel
    {
        public List<Order> Orders { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
