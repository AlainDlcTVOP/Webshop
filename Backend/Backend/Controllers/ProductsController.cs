using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using Backend.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

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

        public IQueryable<ProductDTO> GetAll()
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
    }
}
