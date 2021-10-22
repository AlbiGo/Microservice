using OrderApi.Data.Entities;
using OrderApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> repository)
        {
            _orderRepository = repository;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                return _orderRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public Order GetById(string id)
        {
            try
            {
                var order = _orderRepository.GetAll().AsQueryable().Where(p => p.Id == Guid.Parse(id)).FirstOrDefault();
                return order;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                var result = await _orderRepository.AddAsync(order);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
         }
        public async Task<Order> CheckOut(string orderId)
        {
            try
            {
                var order = _orderRepository.GetAll().Where(p => p.Id == Guid.Parse(orderId)).FirstOrDefault();
                order.Bompleted = true;
                var result = await _orderRepository.UpdateAsync(order);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Order> CancellOrder(string orderId)
        {
            try
            {
                var order = _orderRepository.GetAll().Where(p => p.Id == Guid.Parse(orderId)).FirstOrDefault();
                order.Cancelled = false;
                var result = await _orderRepository.UpdateAsync(order);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
