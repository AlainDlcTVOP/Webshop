namespace Backend.Models
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double RowAmount { get; set; }
    }
}
