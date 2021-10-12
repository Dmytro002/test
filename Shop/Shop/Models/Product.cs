using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1,Int32.MaxValue)]
        public double Price { get; set; }
        public string Image { get; set; }
        [Display(Name = "Category Type")]
        public int CategoryId { get; set;}
        [ForeignKey("CategotyId")]
        public virtual Category Category { get; set; }
    }
}