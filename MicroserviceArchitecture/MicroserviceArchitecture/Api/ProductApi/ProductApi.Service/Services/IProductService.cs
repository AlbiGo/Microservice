using ProductApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApi.Service.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public decimal GetProductPrice(string id);


    }
}
