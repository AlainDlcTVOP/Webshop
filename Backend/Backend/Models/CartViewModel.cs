using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;

namespace Backend.Models
{
    public class CartViewModel 
    {
        public double TotalPrice { get; set; }

        public string errorMessage { get; set; }

        public List<Product> productsList = new List<Product>();
    }
}
