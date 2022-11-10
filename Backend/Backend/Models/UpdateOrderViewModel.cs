using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class UpdateOrderViewModel
    {
        [HiddenInput]
        [Required]
        public int Id { get; set; }

        //[Required]
        //public string UserId { get; set; }

        [Required]
        public string Date { get; set; }

        public string ShippedDate { get; set; }

        public string DeliveryDate { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public class Item
        {
            public int ProductID { get; set; }

            public string Name { get; set; }

            public double Price { get; set; }

            public int Quantity { get; set; }

            public double RowAmount { get; set; }
        }

        [Required]
        public List<Item> Items { get; set; }
    }
}
