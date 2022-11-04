using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using Backend.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public Products(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<ProductDTO> GetAllProducts() //api/products
        {
            var products = from p in _context.Products
                         .Include(p => p.Images)
                           select new ProductDTO()
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Description = p.Description,
                               Price = p.Price,
                               Images = p.Images.Select(i => new ImageDTO { Id = i.Id, ProductID = i.ProductID, Name = i.Name, Src = i.Src, Alt = i.Alt}).ToList(),
                               InStock = p.InStock,
                           };
            return products;
        }


        [HttpGet("{id}")] //api/products/3
        public IActionResult GetProduct(int id)
        {
            var product = from p in _context.Products
                          .Where(p => p.Id == id)
                          .Include(p => p.Images)
                            select new ProductDTO()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Description = p.Description,
                                Price = p.Price,
                                Images = p.Images.Select(i => new ImageDTO { Id = i.Id, ProductID = i.ProductID, Name = i.Name, Src = i.Src, Alt = i.Alt }).ToList(),
                                InStock = p.InStock,
                            };

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Product product = new() 
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                InStock = model.InStock
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] UpdateProductViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var product = _context.Products.Include(p => p.Images).Where(p => p.Id == model.Id).ToList().First();

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.InStock = model.InStock;

                _context.Update(product);
                _context.SaveChanges();

                return new NoContentResult();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
