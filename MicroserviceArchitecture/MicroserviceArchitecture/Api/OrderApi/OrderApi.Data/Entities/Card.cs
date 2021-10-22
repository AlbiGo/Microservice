using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderApi.Data.Entities
{
    public class Card
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid? UserId { get; set; }
        //[Required]
        public  Guid?  OrderId { get; set; }
        [Required]
        public Guid? ProductId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
    }
}
