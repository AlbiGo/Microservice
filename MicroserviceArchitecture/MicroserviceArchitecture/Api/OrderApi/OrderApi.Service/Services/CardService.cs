using OrderApi.Data.Entities;
using OrderApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Services
{
    public class CardService : ICardService
    {
        private IRepository<Card> _repository;
        private IRepository<Order> _orderRepository;



        public CardService(IRepository<Card> repository , IRepository<Order> orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }

        public IEnumerable<Card> GetAllOrders()
        {
            try
            {
                return _repository.GetAll().Where(p => p.OrderId != null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Card GetById(string id)
        {
            try
            {
                var order = _repository.GetAll().AsQueryable().Where(p => p.Id == Guid.Parse(id)).FirstOrDefault();
                return order;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Card> AddProduct(Card card)
        {
            try
            {
              return  await _repository.AddAsync(card);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Card> AddProductToCard(string cardId , string productId)
        {
            try
            {
                var allCards = this.GetAllOrders().ToList();
                var card = allCards.Where(p => p.Id == Guid.Parse(cardId) && p.ProductId == Guid.Parse(productId)).FirstOrDefault();
                if (card != null)
                {
                    card.Quantity++;
                    var cardUpdateed = await _repository.UpdateAsync(card);
                    var order = this.GetOrder(card.OrderId.ToString());
                    order.Total = card.Quantity * this.GetProductPrice(productId);
                    await _orderRepository.UpdateAsync(order);
                    return cardUpdateed;

                }
                return null;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private Order GetOrder(string cardId)
        {
            try
            {
                var order = _orderRepository.GetAll().Where(p => p.Id.Equals(Guid.Parse(cardId))).FirstOrDefault();
                return order;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private decimal GetProductPrice(string productId)
        {
            try
            {
                var uri = "http://localhost:82/api/product/v1/GetProductPrice?productId=" + productId;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                var resposne = "";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    resposne = reader.ReadToEnd();
                }
                return decimal.Parse(resposne.Split('.')[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
