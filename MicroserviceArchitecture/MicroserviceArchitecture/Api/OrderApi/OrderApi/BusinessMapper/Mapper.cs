using OrderApi.Data.Entities;
using OrderApi.Models.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.BusinessMapper
{
    public static class Mapper
    {
        public static Card MapFromDto(AddToCardDTO dTO)
        {
            try
            {
                var Card = new Card()
                { ProductId = dTO.ProductId,
                Quantity = dTO.Quantity,
                UserId = dTO.UserId
                };
                return Card;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
