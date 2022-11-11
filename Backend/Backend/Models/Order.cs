using System.Diagnostics;

namespace SkiShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        //public int OrderNr { get; set; }

        //public int CustomerID { get; set; }

        public string ApplicationUserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime ShippedDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }


        // Navigation property
        public List<OrderItem> Items { get; set; }
    }
}
