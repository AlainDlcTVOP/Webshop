using SkiShop.Models;

namespace Backend.Models
{
    public class AllOrdersViewModel
    {
        public List<CustomerOrderViewModel> CustomerOrders { get; set; } = new List<CustomerOrderViewModel>();
    }
}
