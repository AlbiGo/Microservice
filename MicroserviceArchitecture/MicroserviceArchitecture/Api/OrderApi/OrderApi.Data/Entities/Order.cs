using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderApi.Data.Entities
{
    public class Order
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public decimal Total { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required]
        public bool Bompleted { get; set; }
        [Required]
        public bool Cancelled { get; set; }

        public Order()
        {
            Cancelled = false;
            DateCreated = DateTime.Now;
            Bompleted = false;
        }


    }
}
