using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylShop.Models
{
    public class VinylPlayer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Connectivity { get; set; }
        [Required]
        public string Speed { get; set; }
        [Required]
        public string Motor { get; set; }
        [Required]
        public string Dimensions { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        [Range(1, 100000)]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        [ValidateNever]
        public Manufacturer Manufacturer { get; set; }
    }
}
