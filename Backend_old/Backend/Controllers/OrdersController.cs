using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiShop.Models;
using System.Data;
using System.Drawing;
using System.Net;
using static NuGet.Packaging.PackagingConstants;

namespace Backend.Controllers
{
    public class Orders : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public Orders(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            List<Order> allOrders = _context.Orders.Include(o => o.Items).ToList();

            AllOrdersViewModel viewModel = new();

            foreach (Order order in allOrders)
            {
                ApplicationUser customer = _userManager.Users.First(u => u.Id == order.ApplicationUserId);

                CustomerOrderViewModel customerOrder = new()
                {
                    Order = order,
                    Customer = customer,
                };

                viewModel.CustomerOrders.Add(customerOrder);
            }

            return PartialView("_OrdersList", viewModel);
        }


        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public IActionResult GetOrder(int id)
        {
            Order order = _context.Orders.Include(o => o.Items).First(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                CustomerOrderViewModel viewModel = new()
                {
                    Order = order,
                    Customer = _userManager.Users.First(u => u.Id == order.ApplicationUserId)
                };

                return PartialView("_OrderPage", viewModel);
            }
        }


        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUserOrders()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            List<Order> orders = _context.Orders.Include(o => o.Items).Where(o => o.ApplicationUserId == currentUser.Id).ToList();

            CustomerOrdersViewModel viewModel = new()
            {
                Orders = orders,
                Customer = currentUser
            };

            return PartialView("_UserOrdersList", viewModel);
        }


        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)  //Nota bene: do not use FromForm attribute, it prevents order items from being added to database
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Order order = new()
            {
                ApplicationUserId = model.UserId,
                Date = DateTime.Parse(model.Date),
                OrderAmount = model.OrderAmount,
                ShippedDate = new DateTime(),
                DeliveryDate = new DateTime(),
                Status = "Pending",
                Comments = model.Comments ?? "",
                Items = model.Items.Select(i => new OrderItem { ProductID = i.ProductID, Name = i.Name, Price = i.Price, Quantity = i.Quantity, RowAmount = i.RowAmount }).ToList(),
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateOrder(int orderID)
        {
            var order = _context.Orders.Include(o => o.Items).Where(o => o.Id == orderID).FirstOrDefault();

            if (order == null) 
            { 
                return NotFound();
            }
            else
            {
                string dateFormat = "yyyy-MM-dd";
                UpdateOrderViewModel viewModel = new()
                {
                    Id= order.Id,
                    OrderNr = order.OrderNr,
                    Date = order.Date.ToString(dateFormat),
                    ShippedDate = order.ShippedDate.ToString(dateFormat),
                    DeliveryDate= order.DeliveryDate.ToString(dateFormat),
                    Status = order.Status,
                    Comments = order.Comments,
                    //Items = order.Items.Select(i => new UpdateOrderViewModel.Item { ProductID = i.ProductID, Price = i.Price, Quantity = i.Quantity, RowAmount = i.RowAmount}).ToList()
                };

                return PartialView("_UpdateOrder", viewModel);
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var order = _context.Orders.Include(o => o.Items).First(o => o.Id == model.Id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                order.ShippedDate = model.ShippedDate == null ? new DateTime() : DateTime.Parse(model.ShippedDate);
                order.DeliveryDate = model.DeliveryDate == null ? new DateTime() : DateTime.Parse(model.DeliveryDate);
                order.Status = model.Status ?? "";
                order.Comments = model.Comments ?? "";
                //order.Items = model.Items.Select(i => new OrderItem { ProductID = i.ProductID, Name = i.Name, Price = i.Price, Quantity = i.Quantity, RowAmount = i.RowAmount }).ToList();

                _context.Update(order);
                await _context.SaveChangesAsync();
            }

            return new NoContentResult();
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }

    }
}
