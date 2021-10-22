using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models.RequestDTO
{
    public class CheckOutDTO
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid? OrderId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
