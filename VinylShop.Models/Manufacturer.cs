using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylShop.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Manufacturer")]
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
    }
}
