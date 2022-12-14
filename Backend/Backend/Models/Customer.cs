namespace SkiShop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address{ get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        // Navigation property
        public List<Order> Orders { get; set; }
    }
}
