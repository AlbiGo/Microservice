using OrderApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Services
{
    public interface ICardService
    {
        public  Task<Card> AddProduct(Card card);
        public Task<Card> AddProductToCard(string cardId, string productId);


    }
}
