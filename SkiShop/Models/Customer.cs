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
        public string email { get; set; }
        public string password { get; set; }
        public bool Admin { get; set; }
    }
}
