using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylShop.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Author")]
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
