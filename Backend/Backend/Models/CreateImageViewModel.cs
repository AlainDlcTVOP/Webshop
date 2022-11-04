using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Backend.Models
{
    public class CreateImageViewModel
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Src { get; set; }

        [Required]
        public string Alt { get; set; }
    }
}
