using OrderApi.Data.Entities;
using OrderApi.Models.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Middleware
{
    public interface ICardMiddleware
    {
        public Task<Card> AddProduct(AddToCardDTO card);
        public Task CheckOut(string orderID);


    }
}
