using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkiShop.Models;
using Backend.Data;
using Backend.Models;

namespace SkiShop.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> Get()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _context.Products.Include(item => item.Name);
            }
        }

        public Product Get(int Id)
        {
            return _context.Products.FirstOrDefault(ski => ski.Id == Id);
        }
    }
}
