namespace SkiShop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        //public int OrderNumber { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity{ get; set; }

        public double RowAmount { get; set; }


        //Navigation properties
        public Order Order { get; set; }

        //public Product Product { get; set; } = new Product();

    }
}
