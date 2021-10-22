using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Middleware;
using OrderApi.Models.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Controllers
{
    [Route("api/card/v1")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardMiddleware cardMiddleware;
        public CardController(ICardMiddleware _cardMiddleware)
        {
            cardMiddleware = _cardMiddleware;
        }

        [Route("AddToCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> AddToCard(AddToCardDTO addToCardDTO)
        {
            try
            {
                var result =  await cardMiddleware.AddProduct(addToCardDTO);
                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("CheckOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult> CheckOut(CheckOutDTO dto)
        {
            try
            {
                 await cardMiddleware.CheckOut(dto.OrderId.ToString());
                return Ok();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
