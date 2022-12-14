using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SkiShop.Models;

namespace Backend.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public List<CartContent> CartContents { get; set; }

        private readonly ApplicationDbContext _context;
        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetShoppingCartTotal()
        {
            var total = _context.CartContents
                .Where(cart => cart.ShoppingCartId == ShoppingCartId)
                .Select(cart => cart.Product.Price * cart.Quantity).Sum();

            return (int)total;
        }

        public List<CartContent> GetShoppingCartItems()
        {
            return CartContents ??
                (CartContents = _context.CartContents
                    .Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Include(a => a.Product)
                    .ToList());
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddProductToCart(Product product, int amount)
        {

            var cartContent = _context.CartContents.SingleOrDefault(
                item => item.Product.Id == product.Id && item.ShoppingCartId == ShoppingCartId);

            if (cartContent == null)
            {
                cartContent = new CartContent
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = amount
                };
                _context.CartContents.Add(cartContent);
            }

            else
            {
                var total = cartContent.Quantity + amount;

                cartContent.Quantity = total;
            }

            _context.SaveChanges();
        }

        public void UpdateCart(Product product, int amount)
        {
            var cartContent = _context.CartContents.SingleOrDefault(
                item => item.Product.Id == product.Id && item.ShoppingCartId == ShoppingCartId);

            if (amount == 0)
            {
                _context.CartContents.Remove(cartContent);
                _context.SaveChanges();
            }

            else
            {
                cartContent.Quantity = amount;
                _context.SaveChanges();
            }
        }

        public int RemoveProductFromCart(Product product)
        {
            var cartContent = _context.CartContents.SingleOrDefault(
                item => item.Product.Id == product.Id &&
                item.ShoppingCartId == ShoppingCartId);

            var totalContent = cartContent.Quantity;

            _context.CartContents.Remove(cartContent);
            _context.SaveChanges();

            return totalContent;
        }

        public void ResetCart()
        {
            var cartItems = _context
                .CartContents
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.CartContents.RemoveRange(cartItems);

            _context.SaveChanges();
        }
    }
}


