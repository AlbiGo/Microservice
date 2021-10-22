using ProductApi.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Middleware
{
    public interface IClientMiddleware
    {
        public List<ProductDTO> GetAlProducts();
        public decimal GetProductPrice(string productId);


    }
}
