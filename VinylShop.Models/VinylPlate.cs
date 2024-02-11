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
    public class VinylPlate
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Format { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [Range(1, 50000)]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 50000)]
        [Display(Name = "Price for 1-10")]
        public double Price { get; set; }
        [Required]
        [Range(1, 50000)]
        [Display(Name = "Price for 11-50")]
        public double Price10 { get; set; }
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 50000)]
        public double Price50 { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        [Display(Name = "Label")]
        public int LabelId { get; set; }
        [ForeignKey("LabelId")]
        [ValidateNever]
        public Label Label { get; set; }
        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [ValidateNever]
        public Author Author { get; set; }
    }
}