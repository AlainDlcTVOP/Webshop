using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using Backend.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Hosting;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private IWebHostEnvironment _environment;
        public Products(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult GetAllProducts() //api/products
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

            return Ok(products);
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
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductViewModel model)
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
            await _context.SaveChangesAsync();

            foreach (var item in model.Images)
            {

                if (item.FileName == null || item.FileName.Length == 0)
                {
                    return Content("File not selected");
                }

                var path = Path.Combine(_environment.WebRootPath, "img/", item.FileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                    stream.Close();
                }

                Image image = new()
                {
                    ProductID = product.Id,
                    Name = item.FileName,
                    Src = path,
                };

                _context.Images.Add(image);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
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
