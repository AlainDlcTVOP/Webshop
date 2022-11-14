using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Backend.Models
{
    public class UpdateProductViewModel
    {
        [HiddenInput]
        [Required]
        public int Id { get; set; } = 0;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        //optional
        //public List<IFormFile> Images { get; set; }

        [Required]
        public double Price { get; set; } = 0;

        [Required]
        public int InStock { get; set; } = 0;
    }
}
