using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace SkiShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNr { get; set; }

        //public int CustomerID { get; set; }

        public string ApplicationUserId { get; set; }

        public DateTime Date { get; set; }

        public double OrderAmount { get; set; } = 0;

        public DateTime ShippedDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }


        // Navigation property
        public List<OrderItem> Items { get; set; }
    }
}
