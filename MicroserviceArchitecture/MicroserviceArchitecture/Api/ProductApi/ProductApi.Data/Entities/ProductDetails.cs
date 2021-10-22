using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductApi.Data.Entities
{
    public class ProductDetails
    {
        [Required]
        public Guid ProductDetailsId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string  LongDescription { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
