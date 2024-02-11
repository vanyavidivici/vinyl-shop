using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylShop.Models
{
    public class Label
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Label")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
