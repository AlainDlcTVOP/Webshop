﻿using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiShop.Models;
using System.Data;
using System.Net;
using static NuGet.Packaging.PackagingConstants;

namespace Backend.Controllers
{
    public class Orders : Controller
    {
        private readonly ApplicationDbContext _context;


        public Orders(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet] // api/orders
        public IActionResult GetAllOrders()
        {
            OrdersViewModel viewModel = new()
            {
                Orders = _context.Orders.Include(o => o.Items).ToList()
            };

            return PartialView("_OrdersList", viewModel);

            //var allOrders = from o in _context.Orders
            //        .Include(o => o.Items)
            //                        select new OrderDTO()
            //                        {
            //                            Id = o.Id,
            //                            UserId = o.ApplicationUserId,
            //                            Date = o.Date,
            //                            ShippedDate = o.ShippedDate,
            //                            DeliveryDate = o.DeliveryDate,
            //                            Status = o.Status,
            //                            Comments = o.Comments,
            //                            Items = o.Items.Select(i => new OrderItemDTO
            //                            {
            //                                Id = i.Id,
            //                                OrderID = i.OrderID,
            //                                ProductID = i.ProductID,
            //                                Name = i.Name,
            //                                Price = i.Price,
            //                                Quantity = i.Quantity,
            //                                RowAmount = i.RowAmount
            //                            }).ToList(),
            //                        };
            //return Ok(allOrders);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id:int}")] // api/orders/3
        public IActionResult GetOrder(int id)
        {

            Order order = _context.Orders.Include(o => o.Items).First(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                var orderDTO = new OrderDTO()
                {
                    Id = order.Id,
                    UserId = order.ApplicationUserId,
                    Date = order.Date,
                    ShippedDate = order.ShippedDate,
                    DeliveryDate= order.DeliveryDate,
                    Status= order.Status,
                    Comments = order.Comments,
                    Items = order.Items.Select(item => new OrderItemDTO
                    {
                        Id = item.Id,
                        OrderID = item.OrderID,
                        ProductID = item.ProductID,
                        Name = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        RowAmount = item.RowAmount
                    }).ToList(),
                };

                return Ok(orderDTO);
            }
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{userId}")] // api/orders/d690b5b0-a962-4e56-9a29-bdf2eaa7d969
        public IActionResult GetUserOrders(string userId)
        {
            var userOrders = from o in _context.Orders
             .Include(o => o.Items)
             .Where(o => o.ApplicationUserId == userId)
                         select new OrderDTO()
                         {
                             Id = o.Id,
                             UserId = o.ApplicationUserId,
                             Date = o.Date,
                             ShippedDate = o.ShippedDate,
                             DeliveryDate = o.DeliveryDate,
                             Status = o.Status,
                             Comments = o.Comments,
                             Items = o.Items.Select(i => new OrderItemDTO
                             {
                                 Id = i.Id,
                                 OrderID = i.OrderID,
                                 ProductID = i.ProductID,
                                 Name = i.Name,
                                 Price = i.Price,
                                 Quantity = i.Quantity,
                                 RowAmount = i.RowAmount
                             }).ToList(),
                         };

            return Ok(userOrders);
        }



        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel model)  //Nota bene: do not use FromForm attribute, it prevents order items from being added to database
        {
            if (model == null)
            {
                return BadRequest();
            }

            Order order = new()
            {
                ApplicationUserId = model.UserId,
                Date = DateTime.Parse(model.Date),
                Status = "Pending",
                Comments = model.Comments ?? "",
                Items = model.Items.Select(i => new OrderItem { ProductID = i.ProductID, Name = i.Name, Price = i.Price, Quantity = i.Quantity, RowAmount = i.RowAmount}).ToList(),
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderViewModel model)
        {
            if (model == null)
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
                order.Date = DateTime.Parse(model.Date);
                order.ShippedDate = model.ShippedDate == "" ? new DateTime() : DateTime.Parse(model.ShippedDate);
                order.DeliveryDate = model.DeliveryDate == "" ? new DateTime() : DateTime.Parse(model.DeliveryDate);
                order.Status = model.Status;
                order.Comments = model.Comments;
                order.Items = model.Items.Select(i => new OrderItem { ProductID = i.ProductID, Name = i.Name, Price = i.Price, Quantity = i.Quantity, RowAmount = i.RowAmount }).ToList();

                _context.Update(order);
                await _context.SaveChangesAsync();
            }

            return new NoContentResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
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
