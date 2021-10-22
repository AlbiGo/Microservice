using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models.RequestDTO
{
    public class AddToCardDTO
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public Guid? CartId { get; set; }
        public Guid? OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
