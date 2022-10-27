using System.Diagnostics;

namespace SkiShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNr { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}
