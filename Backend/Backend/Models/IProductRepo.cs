using System.Collections.Generic;
using System;
using SkiShop.Models;

namespace Backend.Models
{

    public interface IProductRepo
    {
        public List<Product> Get();
        IEnumerable<Product> AllProducts { get; }
        public Product Get(int id);
    }
}
