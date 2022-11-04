﻿namespace Backend.Models
{
    public class ProductDTO
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ImageDTO> Images { get; set; } = new List<ImageDTO>();
        public double Price { get; set; } = 0;
        public int InStock { get; set; } = 0;
    }
}
