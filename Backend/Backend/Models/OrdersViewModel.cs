﻿using SkiShop.Models;

namespace Backend.Models
{
    public class OrdersViewModel
    {
        public List<Order> Orders { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}