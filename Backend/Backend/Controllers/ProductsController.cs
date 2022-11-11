using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using Backend.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class Products : Controller
    {
        private readonly ApplicationDbContext _context;

        private IWebHostEnvironment _environment;


        public Products(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        [HttpGet]
        public IActionResult GetAllProducts()
        {
            ProductsViewModel viewModel = new()
            {
                Products = _context.Products.Include(p => p.Images).ToList()
            };

            return PartialView("_ProductsList", viewModel);

            //var products = from p in _context.Products
            //             .Include(p => p.Images)
            //               select new ProductDTO()
            //               {
            //                   Id = p.Id,
            //                   Name = p.Name,
            //                   Description = p.Description,
            //                   Price = p.Price,
            //                   Images = p.Images.Select(i => new ImageDTO { Id = i.Id, ProductID = i.ProductID, Name = i.Name, Src = i.Src, Alt = i.Alt}).ToList(),
            //                   InStock = p.InStock,
            //               };

            //return Ok(products);

        }


        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            ProductViewModel viewModel = new()
            {
                Product = _context.Products.Include(p => p.Images).First(p => p.Id == id)
            };

            return PartialView("_ProductPage", viewModel);
            //var product = from p in _context.Products
            //              .Where(p => p.Id == id)
            //              .Include(p => p.Images)
            //              select new ProductDTO()
            //              {
            //                  Id = p.Id,
            //                  Name = p.Name,
            //                  Description = p.Description,
            //                  Price = p.Price,
            //                  Images = p.Images.Select(i => new ImageDTO { Id = i.Id, ProductID = i.ProductID, Name = i.Name, Src = i.Src, Alt = i.Alt }).ToList(),
            //                  InStock = p.InStock,
            //              };

            //if (product == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(product);
            //}
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateProduct()
        {
            CreateProductViewModel viewModel = new();
            return PartialView("_CreateProduct", viewModel);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // add product
            Product product = new()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                InStock = model.InStock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);

            // add image(s)
            //foreach (var item in model.Images)
            //{

            //    if (item.FileName == null || item.FileName.Length == 0)
            //    {
            //        return Content("File not selected");
            //    }

            //    var path = Path.Combine(_environment.WebRootPath, "image/", item.FileName);

            //    using (FileStream stream = new FileStream(path, FileMode.Create))
            //    {
            //        await item.CopyToAsync(stream);
            //        stream.Close();
            //    }

            //    Image image = new()
            //    {
            //        ProductID = product.Id,
            //        Name = item.FileName,
            //        Src = path,
            //    };

            //    _context.Images.Add(image);
            //    await _context.SaveChangesAsync();
            //}

        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = _context.Products.Include(p => p.Images).First(product => product.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                UpdateProductViewModel viewModel = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    InStock = product.InStock
                };

                return PartialView("_UpdateProduct", viewModel);
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = _context.Products.Include(p => p.Images).First(product => product.Id == model.Id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                // update product
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.InStock = model.InStock;

                _context.Update(product);
                await _context.SaveChangesAsync();
                return new NoContentResult();

                ////add image(s)
                //foreach (var item in model.Images)
                //{

                //    if (item.FileName == null || item.FileName.Length == 0)
                //    {
                //        return Content("File not selected");
                //    }

                //    var path = Path.Combine(_environment.WebRootPath, "images/", item.FileName);

                //    using (FileStream stream = new FileStream(path, FileMode.Create))
                //    {
                //        await item.CopyToAsync(stream);
                //        stream.Close();
                //    }

                //    Image image = new()
                //    {
                //        ProductID = product.Id,
                //        Name = item.FileName,
                //        Src = path,
                //    };

                //    _context.Images.Add(image);
                //    await _context.SaveChangesAsync();
                //}
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return new NoContentResult();
            }
        }
    }
}
