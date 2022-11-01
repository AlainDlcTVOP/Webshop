using Microsoft.AspNetCore.Identity;

namespace SkiShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public string Email { get; set; }

        //public string Password { get; set; }
    }
}
