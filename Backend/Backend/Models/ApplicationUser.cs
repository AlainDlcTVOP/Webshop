using Microsoft.AspNetCore.Identity;

namespace SkiShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        // Navigation property
        public List<Order> Orders { get; set; }
    }
}
