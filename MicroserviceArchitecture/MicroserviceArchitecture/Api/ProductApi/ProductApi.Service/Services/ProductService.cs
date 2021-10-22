using ProductApi.Data.Entities;
using ProductApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductApi.Service.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;

        private IRepository<ProductDetails> _productDetailsRepository;
        public ProductService(IRepository<Product> productRepository , IRepository<ProductDetails> productDetailsRepository)
        {
            _productRepository = productRepository;
            _productDetailsRepository = productDetailsRepository;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return _productRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public decimal GetProductPrice(string id)
        {
            try
            {
                var productId =  _productRepository.GetAll().AsQueryable().Where(p => p.ProductId == Guid.Parse(id)).FirstOrDefault().ProductId;
                var productPrice = _productDetailsRepository.GetAll().Where(p => p.ProductId == productId).FirstOrDefault().Price;
                return productPrice;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
