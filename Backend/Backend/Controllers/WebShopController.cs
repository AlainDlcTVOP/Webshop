using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Backend.Data;
using Backend.Models;
using SkiShop.Models;
using Backend.Controllers;
using SkiShop.Controllers;

namespace Backend.Controllers
{
    public class WebShopController : Controller
    {
        private readonly ApplicationDbContext Database;
        private readonly UserManager<ApplicationUser> UserManager;

        public WebShopController(ApplicationDbContext database, UserManager<ApplicationUser> userManager)
        {
            Database = database;
            UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
