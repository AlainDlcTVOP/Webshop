﻿namespace SkiShop.Models
{
    public class Image
    {
        public int Id { get; set; }

        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Src { get; set; }

        public string Alt { get; set; }
    }
}
