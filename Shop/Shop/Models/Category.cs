using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName ("Display Order")]
        [Required]
        [Range(1,Int32.MaxValue)]
        public int DisplayOrder { get; set; }
    }
}