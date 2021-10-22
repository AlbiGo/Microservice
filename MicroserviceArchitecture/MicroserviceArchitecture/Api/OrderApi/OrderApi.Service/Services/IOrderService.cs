using OrderApi.Data.Entities;
using OrderApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Services
{
    public interface IOrderService
    {

        public Task<Order> AddOrder(Order order);
        public Order GetById(string id);
        public Task<Order> CheckOut(string orderId);


    }
}
