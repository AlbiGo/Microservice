using OrderApi.Data.Entities;
using OrderApi.Models.RequestDTO;
using OrderApi.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderApi.Middleware
{
    public class CardMiddleware : ICardMiddleware
    {
        private readonly ICardService _cardService;
        private readonly IOrderService _orderService;

        public CardMiddleware(ICardService cardService, IOrderService orderService)
        {
            _cardService = cardService;
            _orderService = orderService;
        }
        public async Task<Card> AddProduct(AddToCardDTO card) 
        {
            try
            {
                if(card.CartId == null)
                {
                    decimal product = await this.GetProductPrice(card.ProductId.ToString());
                    var order = new Order()
                    {
                        UserId = card.UserId,
                        Total = card.Quantity * product
                    };
                    var resultOrder = await _orderService.AddOrder(order);
                    var cardEntitty = BusinessMapper.Mapper.MapFromDto(card);
                    cardEntitty.OrderId = resultOrder.Id;
                    cardEntitty.Order = resultOrder;
                    var resultCard = _cardService.AddProduct(cardEntitty);
                    return await resultCard;
                }
                else
                {
                    var resultCard =  await _cardService.AddProductToCard(card.CartId.ToString(), card.ProductId.ToString());
                    return resultCard;
                }
               
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private async Task<decimal> GetProductPrice(string productId)
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task CheckOut(string orderID)
        {
            try
            {
               await  _orderService.CheckOut(orderID);

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
