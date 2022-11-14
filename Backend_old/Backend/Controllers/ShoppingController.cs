using Backend.Models;
using Backend.Viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Backend.Controllers
{
    public class ShoppingController : Controller
    {

        private readonly IProductRepo _productRepo;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingController(IProductRepo productRepo, ShoppingCart shoppingCart)
        {
            _productRepo = productRepo;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.CartContents = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public RedirectToActionResult AddToCart(int Id, int Quantity)
        {
            var addedProducts = _productRepo.AllProducts.FirstOrDefault(item => item.Id == Id);

            if (addedProducts != null)
            {
                _shoppingCart.AddProductToCart(addedProducts, Quantity);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int Id)
        {
            var productsToRemove = _productRepo.Get()
                .FirstOrDefault(ski => ski.Id == Id);

            if (productsToRemove != null)
            {
                _shoppingCart.RemoveProductFromCart(productsToRemove);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult UpdateCart(int Id, int Quantity)
        {
            var productToUpdate = _productRepo.Get()
                .FirstOrDefault(ski => ski.Id == Id);

            if (productToUpdate != null)
            {
                _shoppingCart.UpdateCart(productToUpdate, Quantity);
            }
            return RedirectToAction("Index");
        }
    }
}
