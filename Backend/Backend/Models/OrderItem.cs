namespace SkiShop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string Product { get; set; }
        public int Quantity{ get; set; }
        public double Price { get; set; }
        public double RowAmount { get; set; }

    }
}
