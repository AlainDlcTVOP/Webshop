using SkiShop.Models;

namespace Backend.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime ShippedDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }


        // Navigation property
        public List<OrderItemDTO> Items { get; set; }
    }
}
