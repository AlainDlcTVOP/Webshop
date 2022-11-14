using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace Backend.Controllers
{
    public class BasketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BasketController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetShoppingCart()
        {
            var basket = new Basket();

            if(String.IsNullOrEmpty(HttpContext.Session.GetString("customerId")))
                basket = CreateBasket();

            else
                basket = BasketViewModel.Baskets.FirstOrDefault(x => x.CustomerId == HttpContext.Session.GetString("customerId"));
           
                
            return PartialView ("_ShoppingCart", basket);
        }

        [HttpPost]
        public IActionResult AddItemToCart(int productId, int quantity)
        {

            var basket = BasketViewModel.Baskets.FirstOrDefault(x => x.CustomerId == HttpContext.Session.GetString("customerId"));

            basket ??= CreateBasket();

            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            basket.AddItem(product, quantity);
  
            return RedirectToAction(controllerName: "Products", actionName: "GetAllProducts");
        }

        [HttpPut]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var basket = BasketViewModel.Baskets.FirstOrDefault(x => x.CustomerId == HttpContext.Session.GetString("customerId"));

            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            basket.UpdateQuantity(product, quantity);

            return PartialView("_ShoppingCart", basket);

        }

        [HttpDelete]
        public IActionResult RemoveCartItem(int productId)
        {
            var basket = BasketViewModel.Baskets.FirstOrDefault(x => x.CustomerId == HttpContext.Session.GetString("customerId"));

            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            basket.RemoveItem(product);

            return PartialView("_ShoppingCart", basket);
        }

        private Basket CreateBasket()
        {
            var customerId = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("customerId", customerId);
            var basket = new Basket
            {
                CustomerId = customerId
            };

            BasketViewModel.Baskets.Add(basket);
            return basket;
        }
    }
}
