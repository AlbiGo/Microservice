using ProductApi.Middleware;
using ProductApi.Models.ResponseDTO;
using ProductApi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Middleware
{
    public class ClientMiddleware : IClientMiddleware
    {
        private readonly IProductService _productService;

        public ClientMiddleware(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductDTO> GetAlProducts()
        {
            try
            {
                var clients = _productService.GetAllProducts();
                var clientBusiness = BusinessMapper.Mapper.MappClient(clients.ToList());
                return clientBusiness;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal GetProductPrice(string productId)
        {
            try
            {

                return _productService.GetProductPrice(productId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
